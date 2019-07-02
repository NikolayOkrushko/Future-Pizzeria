using Pizzeria.GameModule.AdministratorModule.Test;
using Pizzeria.GameModule.EnvironmentModule;
using Pizzeria.GameModule.RootModule;
using Pizzeria.GameModule.TableModule;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.AdministratorModule
{
    public class AdministratorController : IAdministratorController, IOutAdministratorController
    {
        private TableUniversal freeTable;
        private IAdministrator administrator;
        private IEnvironmentController environmentController;


        public void Init()
        {
            administrator = new GameObject("Administrator").AddComponent<Administrator>();
            administrator.Init(this);

            RootController.OnModuleAreReady += Start;
        }


        public List<TableUniversal> GetTablesHall()
        {
            var tables = environmentController.GetTables();
            return tables;
        }


        public TableUniversal GetFreeVisitorTable()
        {
            if (administrator.GetFreeVisitorTable() != null)
            {
                freeTable = administrator.GetFreeVisitorTable();
                return freeTable;
            }
            return null;
        }

        public void CallTheWaiter(TableUniversal visitorTable)
        {
            administrator.AddTableWaitingForServiceInQueue(visitorTable);
        }

        public void AddOrderToQueueForCooking(TableUniversal visitorTable)
        {
            administrator.AddOrderToQueue(visitorTable);
        }

        public TableUniversal GetVisitorWhoNeedTakeOrder()
        {
            return administrator.GetAcceptAnOrderFromVisitor();
            //return null;
        }

        public ReadyOrder GetTheOrderWhichBringTheVisitor()
        {
            return administrator.GetBearAnOrderToVisitor();
        }


        public TableUniversal GetOrderNeedToPrepared()
        {
            return administrator.GetOrderNeedToPrepared();
        }

        public void AddOrderPrepared(ReadyOrder readyOrder)
        {
            administrator.AddOrderPreparedInQueue(readyOrder);
        }


        private void Start()
        {
            RootController.OnModuleAreReady -= Start;

            environmentController = RootController.GetControllerByType<IEnvironmentController>();

            administrator.GetTableHall();
        }
    }
}
