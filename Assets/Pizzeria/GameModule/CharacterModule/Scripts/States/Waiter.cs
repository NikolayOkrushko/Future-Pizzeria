using UnityEngine;
using Pizzeria.GameModule.CharacterModule.ActionWaiterSet;
using Pizzeria.GameModule.TableModule;
using UnityEngine.AI;
using Pizzeria.GameModule.AdministratorModule;

namespace Pizzeria.GameModule.CharacterModule.States
{
    public class Waiter : MonoBehaviour, IWaiter
    {
        private ICharacterController characterController;
        private IBehaviour currentBehaviuor;
        private TableUniversal currentTable;
        private Animator animator;
        private NavMeshAgent navMeshAgent;



        public void Init(ICharacterController controller)
        {
            characterController = controller;
            animator = GetComponent<Animator>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            Execute();
        }

        public void Execute()
        {
            Cogitation();
        }


        public void Cogitation()
        {
            currentBehaviuor = new Cogitation(this, characterController);
        }

        public void GoTheWaitingArea()
        {
            currentBehaviuor = new GoTheWaitingArea(this, characterController, animator, navMeshAgent);
        }

        public void ApproachTheVisitor(TableUniversal visitorTable)
        {
            currentBehaviuor = new ApproachTheVisitor(this, characterController, animator, visitorTable, navMeshAgent);
        }

        public void TakeAwayReadyOrder(ReadyOrder readyOrder)
        {
            currentBehaviuor = new TakeAwayReadyOrder(this, characterController, animator, navMeshAgent, readyOrder);
        }
    }
}