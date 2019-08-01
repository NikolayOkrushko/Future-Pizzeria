using Pizzeria.GameModule.EnvironmentModule;
using Pizzeria.GameModule.OrderBoardModule;
using Pizzeria.GameModule.RootModule;
using Pizzeria.GameModule.TableModule;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.AdministratorModule
{
    public class AdministratorController : IAdministratorController, IOutAdministratorController
    {
        public event Action OnWorkForWaiter;
        public event Action OnWorkForCook;

        private TableUniversal freeTable;
        private IAdministrator administrator;
        private IEnvironmentController environmentController;


        public void Init()
        {
            RootController.OnModuleAreReady += Start;
        }

        public OrderBoardController GetOrderBoardController()
        {
            var result = environmentController.GetOrderBoardController();
            return result;
        }


        public List<TableUniversal> GetTablesHall()
        {
            var tables = environmentController.GetTables();
            return tables;
        }


        public void RemoveBusyTable(TableUniversal table)
        {
            administrator.RemoveBusyTable(table);
        }


        public TableUniversal GetFreeVisitorTable()
        {
            freeTable = administrator.GetFreeVisitorTable();
            if (freeTable != null)
            {
                return freeTable;
            }
            else
            {
                return null;
            }
        }

        public List<Transform> GetExitPlaces()
        {
            var exitPlace = environmentController.GetExitPlace();
            return exitPlace;
        }

        public List<Transform> GetDefaultWaiterPlaces()
        {
            var defaultWaiterPlaces = environmentController.GetDefaultWaiterPlaces();
            return defaultWaiterPlaces;
        }

        public List<TableUniversal> GetCookTablePlace()
        {
            var cookTablePlaces = administrator.GetCookTablePlace();
            return cookTablePlaces;
        }

        public void CallTheWaiter(TableUniversal visitorTable)
        {
            administrator.AddTableWaitingForServiceInQueue(visitorTable);
            if (OnWorkForWaiter != null)
            {
                OnWorkForWaiter();
            }
        }

        public void AddOrderToQueueForCooking(TableUniversal visitorTable)
        {
            administrator.AddOrderToQueue(visitorTable);
            if (OnWorkForCook != null)
            {
                OnWorkForCook();
            }
        }

        public TableUniversal GetVisitorWhoNeedTakeOrder()
        {
            if (OnWorkForCook != null)
            {
                OnWorkForCook();
            }


            var result = administrator.GetAcceptAnOrderFromVisitor();
            if (result != null)
            {
                return result;

            }
            return null;
        }

        public ReadyOrder GetTheOrderWhichBringTheVisitor()
        {
            var result = administrator.GetBearAnOrderToVisitor();
            return result;
        }

        public void RemoveCookTable(TableUniversal cookTable)
        {
            administrator.RemoveCookTable(cookTable);
        }


        public TableUniversal GetOrderNeedToPrepared()
        {
            return administrator.GetOrderNeedToPrepared();
        }

        public void AddOrderPrepared(ReadyOrder readyOrder)
        {
            administrator.AddOrderPreparedInQueue(readyOrder);
            if (OnWorkForWaiter != null)
            {
                OnWorkForWaiter();
            }
        }


        private void Start()
        {
            RootController.OnModuleAreReady -= Start;

            environmentController = RootController.GetControllerByType<IEnvironmentController>();
            administrator = new GameObject("Administrator").AddComponent<Administrator>();
            administrator.Init(this);

            administrator.GetTableHall();
        }
    }
}
