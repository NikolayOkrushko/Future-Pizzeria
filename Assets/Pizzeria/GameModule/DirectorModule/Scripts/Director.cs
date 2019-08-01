using Pizzeria.GameModule.CharacterModule;
using Pizzeria.GameModule.RootModule;
using UnityEngine;

namespace Pizzeria.GameModule.DirectorModule
{
    public class Director : MonoBehaviour, IDirector
    {
        private IOutDirectorController directorController;
        private ICharacterController characterController;

        public void Init(IOutDirectorController controller)
        {
            directorController = controller;
            characterController = RootController.GetControllerByType<ICharacterController>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CreateACook();
            }

            else if (Input.GetKeyDown(KeyCode.W))
            {
                CreateAWaiter();
            }
        }

        public void CreateACook()
        {
            characterController.CreateCharacter(CharacterConteiner.Cook);
        }

        public void CreateAWaiter()
        {
            characterController.CreateCharacter(CharacterConteiner.Waiter);
        }

        public void UpgradeACook()
        {

        }
    }
}