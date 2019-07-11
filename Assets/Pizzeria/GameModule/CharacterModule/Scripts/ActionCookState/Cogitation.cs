using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.TableModule;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.ActionCookState
{
    public class Cogitation : IBehaviour
    {
        private Cook cookState;
        private ICharacterController characterController;


        public Cogitation(Cook currentCookState, ICharacterController controller)
        {
            cookState = currentCookState;
            characterController = controller;
            Execute();
        }

        public void Execute()
        {
            TakeOrderTheNeedToPrepare();
        }

        private void TakeOrderTheNeedToPrepare()
        {
            var thereIsWork = characterController.TakeOrderTheNeedToPrepare();

            if (thereIsWork != null)
            {
                ChangeState(true, thereIsWork);
            }
            else
            {
                ChangeState(false);
            }
        }

        private void ChangeState(bool thereIsWork, TableUniversal table = null)
        {
            if (thereIsWork)
            {
                cookState.PrepareAnOrder(table);
            }

            else if (!thereIsWork)
            {
                cookState.WaitingForWork();
            }
        }
    }
}
