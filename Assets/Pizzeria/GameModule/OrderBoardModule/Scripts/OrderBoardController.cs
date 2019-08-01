using UnityEngine.UI;
using UnityEngine;

namespace Pizzeria.GameModule.OrderBoardModule
{
    public class OrderBoardController : MonoBehaviour, IOrderBoardController
    {
        [SerializeField] private Text firstBoard;
        [SerializeField] private Text secondBoard;

        public void DisplayInformationOnFirstBoard(string message)
        {
            firstBoard.text = message;
        }

        public void DisplayInformationOnSecondBoard(string message)
        {
            secondBoard.text = message;
        }
    }
}
