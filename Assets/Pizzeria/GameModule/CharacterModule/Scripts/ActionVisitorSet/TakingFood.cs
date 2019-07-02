using UnityEngine;
using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.CharacterModule;
using System;

namespace CharacterModule.ActionVisitorSet
{
    public class TakingFood : IBehaviour
    {
        private Animator animator;
        private Visitor visitorState;
        private ICharacterController characterController;
        private DateTime timer = new DateTime();
        private int[] eatingTimes = { 0, 0, 0, 0 };
        private int changedEatingTime;



        public TakingFood(ICharacterController controller, Visitor currentvisitorState, Animator currentAnimator)
        {
            characterController = controller;
            visitorState = currentvisitorState;
            animator = currentAnimator;
        }



        public void Execute()
        {
            ChooseMealTime();
        }


        private void CustomUpdate()
        {
            timer = timer.AddSeconds(Time.deltaTime);
            var secondLeft = changedEatingTime - timer.Second;

            if (secondLeft == 0)
            {
                LeaveFeedback();
            }
        }


        private void ChooseMealTime()
        {
            var mealTime = UnityEngine.Random.Range(0, eatingTimes.Length);
            changedEatingTime = mealTime;
            PrepareToEat();
            Eat();
        }

        private void PrepareToEat()
        {
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate += CustomUpdate;
        }

        private void Eat()
        {
            animator.SetFloat("Sitting", 2);
        }

        private void LeaveFeedback()
        {
            characterController.LeaveFeedback(true);
        }



        private void LeaveTheHall()
        {
            visitorState.LeaveTheHall(true);
        }
    }
}