using Pizzeria.GameModule.CharacterModule.States;
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
            // Подписатся на Update
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

        private void StartCoocking()
        {
            // Запуск анимации готовки еды
        }

        private void ChangeState()
        {
            cookState.GiveTheFinishOrder(visitorTable);
        }

    }
}
