using CharacterModule.ActionVisitorSet;
using Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet;
using Pizzeria.GameModule.TableModule;
using UnityEngine;
using UnityEngine.AI;

namespace Pizzeria.GameModule.CharacterModule.States
{
    public class Visitor : MonoBehaviour, IVisitor
    {
        public IVisitorAnimatorController visitorAnimatorController { get; private set; }
        private IBehaviour currentBehaviuor;
        private NavMeshAgent navMeshAgent;
        private Animator animator;
        private ICharacterController characterController;
        private TableUniversal currentTable;
        private bool isVisitorHappy;



        public void Init(ICharacterController controller)
        {
            gameObject.AddComponent<VisitorAnimatorController>();
            visitorAnimatorController = GetComponent<VisitorAnimatorController>();

            characterController = controller;
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            SitAtTheTable();
        }

        public void Execute()
        {
            currentBehaviuor.Execute();
        }

        public void SitAtTheTable()
        {
            currentBehaviuor = new TakeATable(characterController, this.transform, this, navMeshAgent, animator);
            Execute();
        }

        public void CallTheWaiter(TableUniversal table)
        {
            currentTable = table;
            currentBehaviuor = new CallTheWaiter(characterController, this, animator, currentTable);
            Execute();
        }

        public void WaitingForTheWaiter()
        {
            currentBehaviuor = new WaitingForTheWaiter(this, characterController, animator, currentTable);
            Execute();
        }


        public void TakingFood()
        {
            currentBehaviuor = new TakingFood(characterController, this, animator);
        }


        public void LeaveTheHall(bool isHappy)
        {
            isVisitorHappy = isHappy;
            currentBehaviuor = new LeaveTheHall(characterController, this, animator, navMeshAgent, isVisitorHappy);
            Execute();
        }
    }
}
