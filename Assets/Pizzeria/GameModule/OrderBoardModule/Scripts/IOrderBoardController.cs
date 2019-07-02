
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;

namespace Pizzeria.GameModule.OrderBoardModule
{
    public interface IOrderBoardController
    {
        void AddTableWhichReadyPlaceOrder(TableUniversal table);
        void DaleteTableWhichReadyPlaceOrder(TableUniversal table);
        void AddOrderWhichIsPrepare(TableUniversal table);
        void DaleteOrderWhichIsPrepare(TableUniversal table);
        void AddReadyOrder(TableUniversal table);
        void DaleteReadyOrder(TableUniversal table);
    }
}