
using Pizzeria.GameModule.TableModule;
using System;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet
{
    public class WaitingForTheWaiter : MonoBehaviour, IBehaviour
    {
        private Visitor visitorState;
        private Animator animator;
        private ICharacterController characterController;
        private TableUniversal table;
        private DateTime timer = new DateTime();
        private int[] waitingTimes = { 10, 12, 16, 19 };
        private int waitingTime;
        private int numberOfAnimationSitting = 2;


        public WaitingForTheWaiter(Visitor currentVisitorState, ICharacterController controller, Animator currentAnimator, TableUniversal currentTable)
        {
            characterController = controller;
            animator = currentAnimator;
            table = currentTable;
            visitorState = currentVisitorState;
        }

        public void Execute()
        {
            visitorState.visitorAnimatorController.OnAnimationEnd += ChangeAnimationWaiting;

            PlayAnimation(2);
            SelectWaitingTime();
            WaitingWaiter();
        }


        private void CustomUpdate()
        {
            timer = timer.AddSeconds(Time.deltaTime);
            var secondLeft = waitingTime - timer.Second;

            if (secondLeft == 0)
            {
                LeaveFeedback();
                LeaveAwayFromHall();
            }
        }

        private void SelectWaitingTime()
        {
            var changeWaitingTime = UnityEngine.Random.Range(0, waitingTimes.Length);
            waitingTime = waitingTimes[changeWaitingTime];
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate += CustomUpdate;
        }

        private void WaitingWaiter()
        {
            table.OnWaiterCome += ChangeStateToTakingFood;
        }

        private void ChangeAnimationWaiting()
        {
            var changeAnimation = UnityEngine.Random.Range(0, numberOfAnimationSitting);
            PlayAnimation(changeAnimation);
        }


        private void PlayAnimation(int indexAnimatioon)
        {
            animator.SetFloat("Sitting", indexAnimatioon);
        }

        private void LeaveFeedback()
        {
            characterController.LeaveFeedback(false);
        }


        private void LeaveAwayFromHall()
        {
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate -= CustomUpdate;
            visitorState.visitorAnimatorController.OnAnimationEnd -= ChangeAnimationWaiting;
            visitorState.LeaveTheHall(false);
        }

        private void ChangeStateToTakingFood()
        {
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate -= CustomUpdate;
            table.OnWaiterCome -= ChangeStateToTakingFood;
            visitorState.visitorAnimatorController.OnAnimationEnd -= ChangeAnimationWaiting;
            visitorState.TakingFood();
        }
    }
}
