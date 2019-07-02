using UnityEngine;

namespace Pizzeria.GameModule.OrderBoardModule
{
    public class OrderBoard : MonoBehaviour
    {
        private IOrderBoardController orderBoardController;

        public OrderBoard(IOrderBoardController controller)
        {
            orderBoardController = controller;
        }
    }
}
