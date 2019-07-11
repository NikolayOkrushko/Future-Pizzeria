using Pizzeria.GameModule.RootModule;
using Pizzeria.GameModule.TableModule;
using System;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet
{
    public class CallTheWaiter : MonoBehaviour, IBehaviour
    {
        private TableUniversal table;
        private Animator animator;
        private ICharacterController characterController;
        private Visitor visitorState;
        private DateTime timer = new DateTime();
        private int[] waitingTimes = { 8, 10, 13, 18 };
        private int waitingTime;



        public CallTheWaiter(ICharacterController controller, Visitor currentVisitorState, Animator currentAnimator, TableUniversal currentTable)
        {
            characterController = controller;
            visitorState = currentVisitorState;
            table = currentTable;
            animator = currentAnimator;
        }


        public void Execute()
        {
            ChooseTimeForOrdering();
            SelectOrder();
        }

        private void CustomUpdate()
        {
            timer = timer.AddSeconds(Time.deltaTime);
            var secondLeft = waitingTime - timer.Second;

            if (secondLeft == 0)
            {
                CallWaiter();
            }
        }


        private void ChooseTimeForOrdering()
        {
            var changeWaitingTime = UnityEngine.Random.Range(0, waitingTimes.Length);
            waitingTime = waitingTimes[changeWaitingTime];
        }


        private void SelectOrder()
        {
            RootController.globalUpdate.OnCustomUpdate += CustomUpdate;
            animator.SetFloat("Sitting", 3);
        }


        private void CallWaiter()
        {
            RootController.globalUpdate.OnCustomUpdate -= CustomUpdate;
            table.CallTheWaiter();
            ChangeStateToWait();
        }

        private void ChangeStateToWait()
        {
            visitorState.WaitingForTheWaiter();
        }
    }
}
