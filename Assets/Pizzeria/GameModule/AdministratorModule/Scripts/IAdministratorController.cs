using Pizzeria.GameModule.EnvironmentModule;
using Pizzeria.GameModule.TableModule;
using System;

namespace Pizzeria.GameModule.AdministratorModule
{
    public interface IAdministratorController
    {
        void Init();
        TableUniversal GetFreeVisitorTable();
        void CallTheWaiter(TableUniversal visitorTable);
        void AddOrderToQueueForCooking(TableUniversal visitorTable);
        TableUniversal GetVisitorWhoNeedTakeOrder();
        ReadyOrder GetTheOrderWhichBringTheVisitor();
        TableUniversal GetOrderNeedToPrepared();
        void AddOrderPrepared(ReadyOrder readyOrder);


    }
}