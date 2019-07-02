
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
        private bool isHappy;


        public LeaveTheHall(ICharacterController controller, Visitor currentVisitorState, Animator currentAnimator, NavMeshAgent currentNavMeshAgent, bool vistorIsHappy)
        {
            characterController = controller;
            isHappy = vistorIsHappy;
            visitorState = currentVisitorState;
            animator = currentAnimator;
            navMeshAgent = currentNavMeshAgent;
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
                OnTargetDestinate();
            }
        }


        private void GetUpFromTheTable()
        {
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
                navMeshAgent.speed = 2f;
                animator.SetFloat("Speed", 2.5f);
            }
            else if (!isHappy)
            {
                navMeshAgent.destination = movePoint.position;
                navMeshAgent.speed = 2f;
                animator.SetFloat("Speed", -1f);
            }

            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate += CustomUpdate;
        }

        private void OnTargetDestinate()
        {
            characterController.RootCharacterModuleTest.GlobalUpdate.OnCustomUpdate -= CustomUpdate;
            animator.SetFloat("Speed", 1f);
            navMeshAgent.isStopped = true;
        }
    }
}
