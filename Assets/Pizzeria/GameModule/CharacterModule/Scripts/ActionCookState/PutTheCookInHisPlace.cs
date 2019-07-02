
using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.TableModule;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.ActionCookState
{
    public class PutTheCookInHisPlace : IBehaviour
    {
        private Cook cookState;
        private ICharacterController characterController;



        public PutTheCookInHisPlace(Cook currentCookState, ICharacterController controller)
        {
            cookState = currentCookState;
            characterController = controller;
            Execute();
        }


        public void Execute()
        {
            GetForPlaceInAdministrator();
        }

        private void GetForPlaceInAdministrator()
        {
            var placeCook = characterController.GetCookPlace();
            var chooseTable = Random.Range(0, placeCook.Length);
            cookState.RememberTheTable(placeCook[chooseTable]);
            var choosePlace = placeCook[chooseTable].GetCookPlace();

        }

        private void PutInPlaceACook(TableUniversal table)
        {
            cookState.transform.position = table.transform.position;

        }

        private void ChangeState()
        {
            cookState.Cogitation();
        }
    }
}
