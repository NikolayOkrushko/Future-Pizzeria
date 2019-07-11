using Pizzeria.GameModule.RootModule;
using Pizzeria.GameModule.TableModule;
using UnityEngine;
using UnityEngine.AI;

namespace Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet
{
    public class TakeATable : MonoBehaviour, IBehaviour
    {
        private Visitor visitorState;
        private TableUniversal currentTable;
        private NavMeshAgent currentNavMeshAgent;
        private Animator currentAnimator;
        private ICharacterController characterController;
        private float rotationSpeed = 3f;
        private Transform currentVisitorTransform;

        public TakeATable(ICharacterController controller, Transform visitorTransform, Visitor currentVisitorState, NavMeshAgent navMeshAgent, Animator animator)
        {
            characterController = controller;
            currentAnimator = animator;
            currentVisitorTransform = visitorTransform;
            visitorState = currentVisitorState;
            currentNavMeshAgent = navMeshAgent;
        }

        public void Execute()
        {
            var table = characterController.GetFreeTable();
            currentTable = table;
            PrepareToMove(currentTable);
        }

        private void CustomUpdate()
        {
            if (currentNavMeshAgent.remainingDistance <= currentNavMeshAgent.stoppingDistance)
            {
                OnTargetDestinate();
            }
        }


        private void PrepareToMove(TableUniversal table)
        {
            var currentTable = table.GetVisitorPlace();
            var choosePlaceToSit = Random.Range(0, currentTable.Length);
            RootController.globalUpdate.OnCustomUpdate += CustomUpdate;

            StartMove(currentTable[choosePlaceToSit]);
        }

        private void StartMove(Transform placeToSit)
        {
            currentAnimator.SetFloat("Speed", 2);
            currentNavMeshAgent.destination = placeToSit.position;
        }

        private void OnTargetDestinate()
        {
            currentNavMeshAgent.isStopped = true;
            currentAnimator.SetFloat("Speed", 1);

            visitorState.transform.LookAt(currentTable.transform.position); // на этом месте должен быть transform элемента, куда должен повернутся посетитель
            SitAtTheTable();
        }


        private void SitAtTheTable()
        {
            currentNavMeshAgent.isStopped = false;
            currentAnimator.SetTrigger("SitDown");
            currentTable.TakeATable(characterController);
            visitorState.visitorAnimatorController.OnAnimationEnd += ChangeStateCallTheWaiter;
            RootController.globalUpdate.OnCustomUpdate -= CustomUpdate;

        }

        private void ChangeStateCallTheWaiter()
        {
            visitorState.CallTheWaiter(currentTable);
            visitorState.visitorAnimatorController.OnAnimationEnd -= ChangeStateCallTheWaiter;
        }
    }
}
