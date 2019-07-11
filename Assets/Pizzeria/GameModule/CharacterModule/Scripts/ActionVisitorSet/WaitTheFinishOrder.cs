using Pizzeria.GameModule.TableModule;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet
{
    public class WaitTheFinishOrder : IBehaviour
    {
        private Visitor visitorState;
        private ICharacterController characterController;
        private Animator animator;
        private TableUniversal table;



        public WaitTheFinishOrder(Visitor currentState, ICharacterController controller, Animator currentAnimator, TableUniversal currentTable)
        {
            visitorState = currentState;
            characterController = controller;
            animator = currentAnimator;
            table = currentTable;

            Execute();
        }


        public void Execute()
        {
            SubscribeToTableEvent();
        }



        private void SubscribeToTableEvent()
        {
            table.OnFoodOnTheTable += ChangeState;
            StartWaitingAnimation();
        }

        private void ChangeAnimation()
        {
            // можно добавить функционал рандомного выбора анимаций
        }

        private void StartWaitingAnimation()
        {
            animator.SetFloat("Animation", 2);
        }

        private void ChangeState()
        {
            table.OnFoodOnTheTable -= ChangeState;
            visitorState.TakeAFood();
        }
    }
}
