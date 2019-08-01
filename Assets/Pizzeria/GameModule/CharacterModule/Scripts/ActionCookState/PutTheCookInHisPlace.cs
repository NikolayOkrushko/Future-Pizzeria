using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.RootModule;
using Pizzeria.GameModule.TableModule;
using UnityEngine;
using UnityEngine.AI;

namespace Pizzeria.GameModule.CharacterModule.ActionCookState
{
    public class PutTheCookInHisPlace : IBehaviour
    {
        private Cook cookState;
        private ICharacterController characterController;
        private Animator animator;
        private NavMeshAgent navMeshAgent;



        public PutTheCookInHisPlace(Cook currentCookState, ICharacterController controller, Animator currentAnimator, NavMeshAgent currentNavmeshAgent)
        {
            cookState = currentCookState;
            characterController = controller;
            animator = currentAnimator;
            navMeshAgent = currentNavmeshAgent;
            Execute();
        }


        public void Execute()
        {
            GetForPlaceInAdministrator();
        }

        private void CustomUpdate()
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                ChangeState();
            }
        }

        private void GetForPlaceInAdministrator()
        {
            var placeCook = characterController.GetCookTablePlace();
            var chooseTable = Random.Range(0, placeCook.Length);
            cookState.RememberTheTable(placeCook[chooseTable]);
            var cookPlaces = placeCook[chooseTable].GetCookPlace();
            var choosePlace = Random.Range(0, cookPlaces.Length);

            MoveTo(cookPlaces[choosePlace]);
            InformAdministratorTheReservationCookTable(placeCook[chooseTable]);
        }

        private void InformAdministratorTheReservationCookTable(TableUniversal cookTable)
        {
            characterController.RemoveCookTable(cookTable);
        }

        private void MoveTo(Transform table)
        {
            RootController.globalUpdate.OnCustomUpdate += CustomUpdate;
            animator.SetFloat("Animation", 1);
            navMeshAgent.destination = table.transform.position;
        }

        private void ChangeState()
        {
            RootController.globalUpdate.OnCustomUpdate -= CustomUpdate;
            animator.SetFloat("Animation", 0);
            cookState.Cogitation();
        }
    }
}
