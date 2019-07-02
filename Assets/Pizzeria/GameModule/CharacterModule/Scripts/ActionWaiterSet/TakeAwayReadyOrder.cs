﻿using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.TableModule;
using UnityEngine;
using UnityEngine.AI;

namespace Pizzeria.GameModule.CharacterModule.ActionWaiterSet
{
    public class TakeAwayReadyOrder : IBehaviour
    {
        private Waiter waiterState;
        private ICharacterController characterController;
        private Animator animator;
        private NavMeshAgent navMeshAgent;
        private ReadyOrder readyOrder;
        private TableUniversal cookTable;
        private TableUniversal visitorTable;
        private bool TakeOrderFromTheCook;



        public TakeAwayReadyOrder(Waiter currentWaiterState, ICharacterController controller, Animator currentAnimator, NavMeshAgent currentNavMeshAgent, ReadyOrder currentReadyOrder)
        {
            waiterState = currentWaiterState;
            characterController = controller;
            animator = currentAnimator;
            navMeshAgent = currentNavMeshAgent;
            readyOrder = currentReadyOrder;
            Execute();
        }


        public void Execute()
        {
            Debug.Log("Execute сработал отлично");
            DetermineWhichCookPickUpOrder();
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate += CustomUpdate;
        }

        private void CustomUpdate()
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                OnTargetDestinate();
            }
        }

        private void OnTargetDestinate()
        {
            navMeshAgent.isStopped = true;

            if (!TakeOrderFromTheCook)
            {
                TurnToCook();
            }

            else if (TakeOrderFromTheCook)
            {
                TurnToVisitor();
            }
        }

        private void DetermineWhichCookPickUpOrder()
        {
            var currentCookTable = readyOrder.CookTable();
            var waiterPlace = currentCookTable.GetWaiterPlace();
            var movePoint = Random.Range(0, waiterPlace.Length);
            cookTable = currentCookTable;
            MoveToChoosesCook(waiterPlace[movePoint]);
        }

        private void MoveToChoosesCook(Transform movePoint)
        {
            animator.SetFloat("Animation", 1);
            navMeshAgent.destination = movePoint.position;
        }

        private void TurnToCook()
        {
            animator.SetFloat("Animator", 0);
            Debug.Log("Успешно повернулся на повара");
            TakeOrderFromTheCook = true;
            waiterState.transform.LookAt(cookTable.transform.position);
            PickUpTheOrderFromTheCook();
        }

        private void PickUpTheOrderFromTheCook()
        {
            // Запуск анимации взять пиццу
            DetermineWhichVisitorToPlaceOrder();
        }

        private void DetermineWhichVisitorToPlaceOrder()
        {
            navMeshAgent.isStopped = false;
            var currentVisitorTable = readyOrder.VisitorTable();
            var waiterPlace = currentVisitorTable.GetWaiterPlace();
            var movePoint = Random.Range(0, waiterPlace.Length);
            visitorTable = currentVisitorTable;
            MoveToChoosesVisitor(waiterPlace[movePoint]);
        }

        private void MoveToChoosesVisitor(Transform movePoint)
        {
            animator.SetFloat("Animation", 2);
            navMeshAgent.destination = movePoint.position;
        }

        private void TurnToVisitor()
        {
            animator.SetFloat("Animation", 0);
            Debug.Log("Успешно повернулся на посетителя");
            waiterState.transform.LookAt(cookTable.transform.position);
            PutOrderOnTheTable();
        }

        private void PutOrderOnTheTable()
        {
            // Запуск анимации ставить на стол пиццу
            ChangeState();
        }

        private void ChangeState()
        {
            navMeshAgent.isStopped = false;
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate -= CustomUpdate;
            Debug.Log("Состояние успешно изменилось ");
            waiterState.Cogitation();
        }
    }
}