using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.TableModule;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.ActionCookState
{
    public class GiveTheFinishOrder : IBehaviour
    {
        private ICharacterController characterController;
        private Cook cookState;
        private TableUniversal visitorTable;
        private ReadyOrder createdReadyOrder;


        public GiveTheFinishOrder(ICharacterController controller, Cook currentCookState, TableUniversal table)
        {
            characterController = controller;
            cookState = currentCookState;
            visitorTable = table;
            Execute();
        }


        public void Execute()
        {
            CreateAFinishedOrder();
        }


        private void CreateAFinishedOrder()
        {
            createdReadyOrder = new ReadyOrder(visitorTable, cookState.cookTable);
            ReturnOrderToAdministrator(createdReadyOrder);
        }

        private void ReturnOrderToAdministrator(ReadyOrder readyOrder)
        {
            characterController.AdministratorController.AddOrderPrepared(readyOrder);
            ChangeState();
        }

        private void ChangeState()
        {
            cookState.Cogitation();
        }
    }
}
