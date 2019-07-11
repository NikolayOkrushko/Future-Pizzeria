using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.RootModule;
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
        private Transform defaultPlace;



        public GoTheWaitingArea(Waiter currentWaiterState, ICharacterController controller, Animator currentAnimator, NavMeshAgent currentNavMeshAgent)
        {
            waiterState = currentWaiterState;
            characterController = controller;
            animator = currentAnimator;
            navMeshAgent = currentNavMeshAgent;
            defaultPlace = currentWaiterState.WaitPointWaiter;
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
            RootController.globalUpdate.OnCustomUpdate += CustomUpdate;
            MoveToPoint(defaultPlace);
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
            RootController.globalUpdate.OnCustomUpdate -= CustomUpdate;
            ChangeState();
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