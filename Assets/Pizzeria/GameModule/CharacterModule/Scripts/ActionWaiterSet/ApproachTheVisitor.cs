using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.TableModule;
using UnityEngine;
using UnityEngine.AI;

namespace Pizzeria.GameModule.CharacterModule.ActionWaiterSet
{
    public class ApproachTheVisitor : IBehaviour
    {
        private Waiter waiterState;
        private ICharacterController characterController;
        private TableUniversal visitorTable;
        private Animator animator;
        private NavMeshAgent navMeshAgent;
        private bool isApproachedTheVisitor;



        public ApproachTheVisitor(Waiter currentWaiterState, ICharacterController controller, Animator currentAnimator, TableUniversal table, NavMeshAgent curremtNavMeshAgent)
        {
            waiterState = currentWaiterState;
            characterController = controller;
            animator = currentAnimator;
            visitorTable = table;
            navMeshAgent = curremtNavMeshAgent;
            Execute();
        }




        public void Execute()
        {
            PrepareForMovenment();
        }


        private void CustomUpdate()
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                StopMove();
            }
        }



        private void PrepareForMovenment()
        {
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate += CustomUpdate;
            ChoosePlaceToBecome();
        }

        private void ChoosePlaceToBecome()
        {
            var placeToBecome = visitorTable.GetWaiterPlace();
            var choosePlace = Random.Range(0, placeToBecome.Length);
            MoveToVisitorTable(placeToBecome[choosePlace]);
        }


        private void MoveToVisitorTable(Transform movePoint)
        {
            animator.SetFloat("Animation", 1);
            navMeshAgent.destination = movePoint.position;
        }

        private void StopMove()
        {
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate -= CustomUpdate;
            navMeshAgent.isStopped = true;

            if (!isApproachedTheVisitor)
            {
                TurnToVisitorTable();
            }
            else if (isApproachedTheVisitor)
            {
                GiveAwayVisitorWhoNeedTakeOrder();
            }
        }

        private void TurnToVisitorTable()
        {
            animator.SetFloat("Animation", 0);
            waiterState.transform.LookAt(visitorTable.transform.position);
            isApproachedTheVisitor = true;
            FindOutWhoSitAtTheTable();
        }

        private void FindOutWhoSitAtTheTable()
        {
            visitorTable.GetVisitor();
        }

        private void WaitUntillTheVisitorChoosesOrder()
        {
            characterController.OnOrderSelected += ChangeCookPlace;
        }

        private void ChangeCookPlace()
        {
            characterController.OnOrderSelected -= ChangeCookPlace;
            var result = characterController.GetCookTablePlace();
            var changeCookPlace = Random.Range(0, result.Length);
            GoToTheCookBar(result[changeCookPlace]);
        }

        private void GoToTheCookBar(TableUniversal cookTable)
        {
            animator.SetFloat("Animation", 1);
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate += CustomUpdate;
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = cookTable.transform.position;
        }

        private void GiveAwayVisitorWhoNeedTakeOrder()
        {
            characterController.AddOrderToQueueForCooking(visitorTable);
            ChangeState();
        }

        private void ChangeState()
        {
            animator.SetFloat("Animation", 0);
            navMeshAgent.isStopped = false;
            waiterState.Cogitation();
        }

    }
}