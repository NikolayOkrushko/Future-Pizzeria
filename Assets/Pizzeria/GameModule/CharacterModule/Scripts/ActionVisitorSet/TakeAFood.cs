using Pizzeria.GameModule.RootModule;
using System;
using UnityEngine;


namespace Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet
{
    public class TakeAFood : IBehaviour
    {
        private Visitor visitorState;
        private ICharacterController characterController;
        private Animator animator;
        private DateTime timer = new DateTime();
        private int[] snacksTime = { 10, 13, 16, 20 };
        private int changedsnackTime;


        public TakeAFood(Visitor currentVisitorState, ICharacterController controller, Animator currentAnimator)
        {
            visitorState = currentVisitorState;
            characterController = controller;
            animator = currentAnimator;
        }


        public void Execute()
        {
            ChangeTimeNeedToSnack();
        }



        private void CustomUpdate()
        {
            timer = timer.AddSeconds(Time.deltaTime);
            var secondLeft = changedsnackTime - timer.Second;

            if (secondLeft == 0)
            {
                FinishEating();
            }
        }


        private void ChangeTimeNeedToSnack()
        {
            var changeTime = UnityEngine.Random.Range(0, snacksTime.Length);
            changedsnackTime = snacksTime[changeTime];
            StartEating();
        }

        private void StartEating()
        {
            RootController.globalUpdate.OnCustomUpdate += CustomUpdate;
            animator.SetFloat("Animation", 2);
        }

        private void FinishEating()
        {
            RootController.globalUpdate.OnCustomUpdate -= CustomUpdate;
            ChangeState();
        }

        private void ChangeState()
        {
            visitorState.LeaveTheHall(true);
        }

    }
}
