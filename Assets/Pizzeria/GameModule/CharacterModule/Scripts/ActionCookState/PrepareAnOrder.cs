using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.RootModule;
using Pizzeria.GameModule.TableModule;
using System;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.ActionCookState
{
    public class PrepareAnOrder : IBehaviour
    {
        private Cook cookState;
        private ICharacterController characterController;
        private Animator animator;
        private TableUniversal visitorTable;
        private DateTime timer = new DateTime();
        private int[] coockingTimes = { 5, 7, 9, 10 };
        private int coockingTime;


        public PrepareAnOrder(Cook currentCookState, ICharacterController controller, Animator currentAnimator, TableUniversal table)
        {
            cookState = currentCookState;
            characterController = controller;
            animator = currentAnimator;
            visitorTable = table;
            Execute();
        }


        public void Execute()
        {
            PrepareForCoocking();
        }



        private void CustomUpdate()
        {
            timer = timer.AddSeconds(Time.deltaTime);
            var secondLeft = coockingTime - timer.Second;

            if (secondLeft == 0)
            {
                ChangeState();
            }
        }

        private void PrepareForCoocking()
        {
            var changeTime = UnityEngine.Random.Range(0, coockingTimes.Length);
            var selectedTime = coockingTimes[changeTime];
            coockingTime = selectedTime;
            RootController.globalUpdate.OnCustomUpdate += CustomUpdate;
        }

        private void StartCoocking()
        {
            animator.SetFloat("Animation", 4);
        }

        private void ChangeState()
        {
            RootController.globalUpdate.OnCustomUpdate -= CustomUpdate;
            cookState.GiveTheFinishOrder(visitorTable);
        }
    }
}
