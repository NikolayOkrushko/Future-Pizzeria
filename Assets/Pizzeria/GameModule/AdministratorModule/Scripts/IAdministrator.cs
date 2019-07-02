using Pizzeria.GameModule.TableModule;

namespace Pizzeria.GameModule.AdministratorModule
{
    public interface IAdministrator
    {
        void Init(IOutAdministratorController controller);
        void GetTableHall();
        TableUniversal GetFreeVisitorTable();
        void AddTableWaitingForServiceInQueue(TableUniversal visitorTable);
        TableUniversal GetAcceptAnOrderFromVisitor();
        ReadyOrder GetBearAnOrderToVisitor();
        void AddOrderToQueue(TableUniversal visitorTable);
        TableUniversal GetOrderNeedToPrepared();
        void AddOrderPreparedInQueue(ReadyOrder readyOrder);


    }
}