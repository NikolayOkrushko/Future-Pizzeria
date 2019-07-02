using Pizzeria.GameModule.CharacterModule.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.ActionCookState
{
    public class WaitingForWork : MonoBehaviour, IBehaviour
    {
        private Cook cookState;
        private ICharacterController characterController;
        private Animator animator;



        public WaitingForWork(Cook currentCookState, ICharacterController currentCharacterController, Animator currentAnimator)
        {
            cookState = currentCookState;
            characterController = currentCharacterController;
            animator = currentAnimator;
            Execute();
        }


        public void Execute()
        {
            SubscribeToOrder();
        }


        private void SubscribeToOrder()
        {
            // Подписатся на событие есть заказ у администратора
        }

        private void StartAnimationWaitingOrder()
        {
            // Запустить анимацию ожидания
        }

        private void ChangeState()
        {
            cookState.Cogitation();
        }
    }
}
