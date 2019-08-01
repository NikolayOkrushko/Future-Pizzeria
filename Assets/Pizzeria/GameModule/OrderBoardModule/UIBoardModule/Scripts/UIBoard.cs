using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace Pizzeria.GameModule.OrderBoardModule.UIBorderModule
{
    public class UIBoard : MonoBehaviour, IUIBoard
    {
        [SerializeField] private List<Text> ordersWaitingForCooking = new List<Text>();
        [SerializeField] private List<Text> readyOrders = new List<Text>();


        public void DisplayOrderMustBePrepared(int tableID)
        {

        }

        public void RemoveFromDisplayOrderMustBePrepared(int tableID)
        {

        }

        public void DisplayReadyOrder(int tableID)
        {

        }

        public void RemoveFromDisplayReadyOrder(int tableID)
        {

        }
    }
}
