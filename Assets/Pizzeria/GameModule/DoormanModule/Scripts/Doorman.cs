using Pizzeria.GameModule.CharacterModule;
using Pizzeria.GameModule.RootModule;
using UnityEngine;

namespace Pizzeria.GameModule.DoormanModule
{
    public class Doorman : MonoBehaviour, IDoorman
    {
        private IOutDoormanController doormanController;
        private ICharacterController characterController;


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RunTheVisitor();
            }
        }


        public void Init(IOutDoormanController controller)
        {
            doormanController = controller;
            characterController = RootController.GetControllerByType<ICharacterController>();
        }


        private void RunTheVisitor()
        {
            characterController.CreateCharacter(CharacterConteiner.Visitor);
        }


    }
}

