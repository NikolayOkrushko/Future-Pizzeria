using Pizzeria.GameModule.CharacterModule.States;
using UnityEngine;
using UnityEngine.AI;

namespace Pizzeria.GameModule.CharacterModule.ActionWaiterSet
{
    public class GoTheWaitingArea : IBehaviour
    {
        private Waiter waiterState;
        ICharacterController characterController;
        private Animator animator;
        private NavMeshAgent navMeshAgent;



        public GoTheWaitingArea(Waiter currentWaiterState, ICharacterController controller, Animator currentAnimator, NavMeshAgent currentNavMeshAgent)
        {
            waiterState = currentWaiterState;
            characterController = controller;
            animator = currentAnimator;
            navMeshAgent = currentNavMeshAgent;
            Execute();
        }

        public void Execute()
        {
            PrepareForTheMoving();
        }

        private void CustomUpdate()
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                StopMoving();
            }
        }

        private void PrepareForTheMoving()
        {
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate += CustomUpdate;
            ChoosePlaceForWaiting();
        }

        private void ChoosePlaceForWaiting()
        {
            var places = characterController.GetPlaceToWait();
            var choosePlace = Random.Range(0, places.Length);
            MoveToPoint(places[choosePlace]);
        }


        private void MoveToPoint(Transform waitPlace)
        {
            animator.SetFloat("Animation", 1);
            navMeshAgent.destination = waitPlace.position;
        }

        private void StopMoving()
        {
            navMeshAgent.isStopped = true;
            animator.SetFloat("Animation", 0);
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate -= CustomUpdate;
        }


        private void TurnToVisitor()
        {
            //waiterState.transform.LookAt(); Поворот к посетителям
        }

        private void ChangeState()
        {
            navMeshAgent.isStopped = false;
            waiterState.Cogitation();
        }

    }
}