using Pizzeria.GameModule.OrderBoardModule;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Linq;
using Pizzeria.GameModule.EnvironmentModule;
using Pizzeria.GameModule.RootModule;

namespace Pizzeria.GameModule.AdministratorModule
{
    public class Administrator : MonoBehaviour, IAdministrator
    {
        private IEnvironmentController environmentController;
        private List<TableUniversal> visitorFreeTables = new List<TableUniversal>();
        private List<TableUniversal> visitorBusyTables = new List<TableUniversal>();
        private Queue<TableUniversal> ordersBegingPrepared = new Queue<TableUniversal>();
        private List<TableUniversal> tablesWaitingForTheWaiter = new List<TableUniversal>();
        private Queue<ReadyOrder> orderPrepareds = new Queue<ReadyOrder>();
        private List<TableUniversal> cookTablePlaces;
        private StringBuilder message = new StringBuilder();
        private OrderBoardController orderBoard;
        private int freeTableIndex;
        private IAdministratorController administratorController;


        public void Init(IAdministratorController controller)
        {
            administratorController = controller;
            orderBoard = administratorController.GetOrderBoardController();
            environmentController = RootController.GetControllerByType<IEnvironmentController>();
            cookTablePlaces = environmentController.GetCookTablePlaces();
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

        public void RemoveBusyTable(TableUniversal table)
        {
            visitorFreeTables.Add(table);
            var currentTable = tablesWaitingForTheWaiter.IndexOf(table);
            if (tablesWaitingForTheWaiter.Contains(table))
            {
                tablesWaitingForTheWaiter.RemoveAt(tablesWaitingForTheWaiter.IndexOf(table));
            }
        }

        public TableUniversal GetFreeVisitorTable()
        {
            var RandomTable = Random.Range(0, visitorFreeTables.Count);
            freeTableIndex = RandomTable;



            if (visitorFreeTables.Count > 0)
            {
                var currentTable = visitorFreeTables[freeTableIndex]; // заменить на freeTableIndex

                AddVisitorBusyTable(currentTable);
                return currentTable;
            }
            return null;
        }

        public List<Transform> GetExitPlaces()
        {
            var exitPlace = administratorController.GetExitPlaces();
            return exitPlace;
        }

        #endregion

        #region Waiter
        public List<Transform> DefaultWaiterPlaces()
        {
            throw new System.NotImplementedException();
        }


        public void AddTableWaitingForServiceInQueue(TableUniversal visitorTable)
        {
            tablesWaitingForTheWaiter.Add(visitorTable);
        }

        public TableUniversal GetAcceptAnOrderFromVisitor()
        {
            if (tablesWaitingForTheWaiter.Count > 0)
            {
                var firstTable = tablesWaitingForTheWaiter.First();
                var checkElementInList = tablesWaitingForTheWaiter.IndexOf(firstTable);
                tablesWaitingForTheWaiter.RemoveAt(checkElementInList);
                return firstTable;
            }
            return null;
        }

        public ReadyOrder GetBearAnOrderToVisitor()
        {
            if (orderPrepareds.Count > 0)
            {
                DisplayReadyOrders();
                var order = orderPrepareds.Dequeue();
                return order;
            }
            return null;
        }
        #endregion

        #region Cook
        public List<TableUniversal> GetCookTablePlace()
        {
            if (cookTablePlaces.Count > 0)
            {
                var result = cookTablePlaces;
                return result;
            }
            return null;
        }

        public void RemoveCookTable(TableUniversal cookTable)
        {
            cookTablePlaces.RemoveAt(cookTablePlaces.IndexOf(cookTable));
        }

        public void AddOrderToQueue(TableUniversal visitorTable)
        {
            ordersBegingPrepared.Enqueue(visitorTable);
            DisplayNewOrders();
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

        private void AddVisitorBusyTable(TableUniversal visitorTable)
        {
            visitorBusyTables.Add(visitorTable);
            visitorFreeTables.RemoveAt(visitorFreeTables.IndexOf(visitorTable));
        }

        private void DisplayNewOrders()
        {
            message.Clear();
            int count = ordersBegingPrepared.Count;

            foreach (var table in ordersBegingPrepared)
            {
                message.Append(table.TableID);
                message.Append(" | ");
            }
            orderBoard.DisplayInformationOnFirstBoard(message.ToString());
        }

        private void DisplayReadyOrders()
        {
            message.Clear();
            int count = orderPrepareds.Count;

            foreach (var order in orderPrepareds)
            {
                message.Append(order.VisitorTable().TableID);
                message.Append(" | ");
            }
            orderBoard.DisplayInformationOnSecondBoard(message.ToString());
        }
    }
}
