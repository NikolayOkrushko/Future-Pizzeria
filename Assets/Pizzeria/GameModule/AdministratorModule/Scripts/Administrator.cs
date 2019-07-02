using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.AdministratorModule
{
    public class Administrator : MonoBehaviour, IAdministrator
    {
        private List<TableUniversal> visitorFreeTables = new List<TableUniversal>();
        private List<TableUniversal> visitorBusyTables = new List<TableUniversal>();
        private Queue<TableUniversal> ordersBegingPrepared = new Queue<TableUniversal>();
        private Queue<TableUniversal> tablesWaitingForTheWaiter = new Queue<TableUniversal>();
        private Queue<ReadyOrder> orderPrepareds = new Queue<ReadyOrder>();


        private int freeTableIndex;
        private IOutAdministratorController administratorController;


        public void Init(IOutAdministratorController controller)
        {
            administratorController = controller;
        }


        #region Out
        public void GetTableHall()
        {
            var tables = administratorController.GetTablesHall();

            foreach (var table in tables)
            {
                visitorFreeTables.Add(table);
            }
        }
        #endregion

        #region Visitor
        public TableUniversal GetFreeVisitorTable()
        {
            var RandomTable = Random.Range(0, visitorFreeTables.Count);
            freeTableIndex = RandomTable;

            if (visitorFreeTables.Count > 0)
            {
                var currentTable = visitorFreeTables[freeTableIndex];


                AddVisitorBusyTable(freeTableIndex);
                return currentTable;
            }
            return null;
        }
        #endregion

        #region Waiter
        public void AddTableWaitingForServiceInQueue(TableUniversal visitorTable)
        {
            tablesWaitingForTheWaiter.Enqueue(visitorTable);
        }

        public TableUniversal GetAcceptAnOrderFromVisitor()
        {
            if (tablesWaitingForTheWaiter.Count > 0)
            {
                return tablesWaitingForTheWaiter.Dequeue();
            }
            return null;
        }

        public ReadyOrder GetBearAnOrderToVisitor()
        {
            if (orderPrepareds.Count > 0)
            {
                return orderPrepareds.Dequeue();
            }
            return null;
        }
        #endregion

        #region Cook
        public void AddOrderToQueue(TableUniversal visitorTable)
        {
            ordersBegingPrepared.Enqueue(visitorTable);
        }

        public TableUniversal GetOrderNeedToPrepared()
        {
            if (ordersBegingPrepared.Count > 0)
            {
                return ordersBegingPrepared.Dequeue();
            }
            return null;
        }

        public void AddOrderPreparedInQueue(ReadyOrder readyOrder)
        {
            orderPrepareds.Enqueue(readyOrder);
        }
        #endregion


        private void AddFreeVisitorTable(TableUniversal visitorTable)
        {
            visitorFreeTables.Add(visitorTable);
        }

        private void AddVisitorBusyTable(int visitorTable)
        {
            visitorBusyTables.Add(visitorFreeTables[visitorTable]);
            visitorFreeTables.RemoveAt(visitorTable);
        }
    }
}
