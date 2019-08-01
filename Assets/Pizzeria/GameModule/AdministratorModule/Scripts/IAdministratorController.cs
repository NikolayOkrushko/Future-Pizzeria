﻿using Pizzeria.GameModule.OrderBoardModule;
using Pizzeria.GameModule.TableModule;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.AdministratorModule
{
    public interface IAdministratorController
    {
        event Action OnWorkForWaiter;
        event Action OnWorkForCook;

        void Init();

        OrderBoardController GetOrderBoardController();
        TableUniversal GetFreeVisitorTable();
        void RemoveBusyTable(TableUniversal table);
        List<TableUniversal> GetTablesHall();
        List<Transform> GetExitPlaces();
        List<Transform> GetDefaultWaiterPlaces();
        List<TableUniversal> GetCookTablePlace();
        void CallTheWaiter(TableUniversal visitorTable);
        void AddOrderToQueueForCooking(TableUniversal visitorTable);
        TableUniversal GetVisitorWhoNeedTakeOrder();
        ReadyOrder GetTheOrderWhichBringTheVisitor();
        void RemoveCookTable(TableUniversal cookTable);
        TableUniversal GetOrderNeedToPrepared();
        void AddOrderPrepared(ReadyOrder readyOrder);


    }
}