
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;

namespace Pizzeria.GameModule.OrderBoardModule
{
    public class OrderBoardControllers : IOrderBoardController
    {
        private OrderBoard orderBoard;

        public OrderBoardControllers()
        {
            orderBoard = new OrderBoard(this);
        }



        public void AddTableWhichReadyPlaceOrder(TableUniversal table)
        {
            // Добавление в таблицу стол который готов сделать заказ
        }

        public void DaleteTableWhichReadyPlaceOrder(TableUniversal table)
        {
            // Удаление  из таблицу стол который готов сделать заказ
        }

        public void AddOrderWhichIsPrepare(TableUniversal table)
        {
            // Добавление в таблицу заказ который готовиться 
        }

        public void DaleteOrderWhichIsPrepare(TableUniversal table)
        {
            // Удаление из таблицы заказ который готовиться 
        }

        public void AddReadyOrder(TableUniversal table)
        {
            //        Добавить заказ который готов 
        }

        public void DaleteReadyOrder(TableUniversal table)
        {
            // Удаление из таблицы заказ который готов
        }
    }
}
