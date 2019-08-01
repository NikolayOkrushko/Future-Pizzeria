using Pizzeria.GameModule.CharacterModule.ActionCookState;
using Pizzeria.GameModule.TableModule;
using UnityEngine.AI;
using UnityEngine;
namespace Pizzeria.GameModule.CharacterModule.States
{
    public class Cook : MonoBehaviour, ICook
    {
        public TableUniversal cookTable { get; private set; }
        private IBehaviour currentBehaviour;
        private ICharacterController characterController;
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
            PutTheCookInHisPlace();
        }


        public TableUniversal RememberTheTable(TableUniversal table)
        {
            var currentCookTable = cookTable = table;
            return currentCookTable;
        }

        public void PutTheCookInHisPlace()
        {
            currentBehaviour = new PutTheCookInHisPlace(this, characterController, animator, navMeshAgent);
        }

        public void Cogitation()
        {
            currentBehaviour = new Cogitation(this, characterController);
        }

        public void WaitingForWork()
        {
            currentBehaviour = new WaitingForWork(this, characterController, animator);
        }

        public void PrepareAnOrder(TableUniversal table)
        {
            currentBehaviour = new PrepareAnOrder(this, characterController, animator, table);
        }

        public void GiveTheFinishOrder(TableUniversal table)
        {
            currentBehaviour = new GiveTheFinishOrder(characterController, this, table);
        }
    }
}
