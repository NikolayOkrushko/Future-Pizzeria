using UnityEngine;
using System;
using Pizzeria.GameModule.RootModule;

namespace Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet
{
    public class DetermineTheOrder : IBehaviour
    {
        private Animator animator;
        private Visitor visitorState;
        private ICharacterController characterController;
        private DateTime timer = new DateTime();
        private int[] changeOrderTime = { 10, 13, 16, 20 };
        private int changedChangeOrderTime;



        public DetermineTheOrder(ICharacterController controller, Visitor currentvisitorState, Animator currentAnimator)
        {
            characterController = controller;
            visitorState = currentvisitorState;
            animator = currentAnimator;
            Execute();
        }



        public void Execute()
        {
            ChooseChangeOrderTime();
        }



        private void CustomUpdate()
        {
            timer = timer.AddSeconds(Time.deltaTime);
            var secondLeft = changedChangeOrderTime - timer.Second;


            if (secondLeft == 0)
            {
                OrderSelected();
            }
        }


        private void ChooseChangeOrderTime()
        {
            var mealTime = UnityEngine.Random.Range(0, changeOrderTime.Length);
            changedChangeOrderTime = changeOrderTime[mealTime];
            PrepareToEat();
        }

        private void PrepareToEat()
        {
            RootController.globalUpdate.OnCustomUpdate += CustomUpdate;
            StartWaitOrderAnimation();
        }

        private void StartWaitOrderAnimation()
        {
            animator.SetFloat("Sitting", 2);
        }

        private void OrderSelected()
        {
            characterController.OrderSelected();
            ChangeState();
        }

        private void ChangeState()
        {
            RootController.globalUpdate.OnCustomUpdate -= CustomUpdate;
            visitorState.WaitTheFinishOrder();
        }
    }
}