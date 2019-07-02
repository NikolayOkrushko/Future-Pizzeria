using Pizzeria.GameModule.CharacterModule.States;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.ActionWaiterSet
{
    public class Cogitation : IBehaviour
    {
        private Waiter waiterState;
        private ICharacterController characterController;


        public Cogitation(Waiter currentWaiterState, ICharacterController controller)
        {
            waiterState = currentWaiterState;
            characterController = controller;
            Execute();
        }

        public void Execute()
        {
            GetVisitorWhoNeedTakeOrder();
        }

        private void GetVisitorWhoNeedTakeOrder()
        {
            var result = characterController.GetVisitorWhoNeedTakeOrder();
            if (result != null)
            {
                waiterState.ApproachTheVisitor(result);
            }
            else
            {
                GetTheOrderWhichBringTheVisitor();
            }
        }

        private void GetTheOrderWhichBringTheVisitor()
        {
            var result = characterController.GetTheOrderWhichBringTheVisitor();
            if (result != null)
            {
                waiterState.TakeAwayReadyOrder(result);
            }
            else
            {
                waiterState.GoTheWaitingArea();
            }
        }
    }
}