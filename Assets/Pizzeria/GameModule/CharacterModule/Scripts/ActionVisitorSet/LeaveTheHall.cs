
using Pizzeria.GameModule.RootModule;
using Pizzeria.GameModule.TableModule;
using UnityEngine;
using UnityEngine.AI;
namespace Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet
{
    public class LeaveTheHall : MonoBehaviour, IBehaviour
    {
        private Animator animator;
        private Visitor visitorState;
        private NavMeshAgent navMeshAgent;
        private ICharacterController characterController;
        private Transform[] exitPlace;
        private TableUniversal table;
        private bool isHappy;


        public LeaveTheHall(ICharacterController controller, Visitor currentVisitorState, Animator currentAnimator, NavMeshAgent currentNavMeshAgent, bool vistorIsHappy, TableUniversal currentTable)
        {
            characterController = controller;
            isHappy = vistorIsHappy;
            visitorState = currentVisitorState;
            animator = currentAnimator;
            navMeshAgent = currentNavMeshAgent;
            table = currentTable;
        }



        public void Execute()
        {
            var receivedExitPlace = characterController.GetExitPlace();
            exitPlace = receivedExitPlace;
            visitorState.visitorAnimatorController.OnAnimationEnd += DefineExit;
            GetUpFromTheTable();
        }


        private void CustomUpdate()
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                Debug.Log("Посетитель идёт в указанную точку");
                OnTargetDestinate();
            }
        }


        private void GetUpFromTheTable()
        {
            table.ReleaseTheTable();
            animator.SetTrigger("StandUp");
        }

        private void DefineExit()
        {
            var exit = Random.Range(0, exitPlace.Length);
            Move(exitPlace[exit]);
        }


        private void Move(Transform movePoint)
        {
            if (isHappy)
            {
                navMeshAgent.destination = movePoint.position;
                navMeshAgent.speed = 4f;
                animator.SetFloat("Speed", 2.5f);
            }
            else if (!isHappy)
            {
                navMeshAgent.destination = movePoint.position;
                navMeshAgent.speed = 2f;
                animator.SetFloat("Speed", -1f);
            }

            RootController.globalUpdate.OnCustomUpdate += CustomUpdate;
        }

        private void OnTargetDestinate()
        {
            RootController.globalUpdate.OnCustomUpdate -= CustomUpdate;
            animator.SetFloat("Speed", 1f);
            navMeshAgent.isStopped = true;
        }
    }
}
