using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.AdministratorModule
{
    public interface IAdministrator
    {
        void Init(IAdministratorController controller);
        void GetTableHall();
        TableUniversal GetFreeVisitorTable();
        List<Transform> GetExitPlaces();
        List<Transform> DefaultWaiterPlaces();
        List<TableUniversal> GetCookTablePlace();
        void AddTableWaitingForServiceInQueue(TableUniversal visitorTable);
        void RemoveBusyTable(TableUniversal table);
        TableUniversal GetAcceptAnOrderFromVisitor();
        ReadyOrder GetBearAnOrderToVisitor();
        void RemoveCookTable(TableUniversal cookTable);
        void AddOrderToQueue(TableUniversal visitorTable);
        TableUniversal GetOrderNeedToPrepared();
        void AddOrderPreparedInQueue(ReadyOrder readyOrder);


    }
}