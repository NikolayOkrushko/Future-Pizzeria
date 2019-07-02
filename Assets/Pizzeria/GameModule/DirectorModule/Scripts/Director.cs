using Pizzeria.GameModule.CharacterModule;
using Pizzeria.GameModule.RootModule;
using UnityEngine;

namespace Pizzeria.GameModule.DirectorModule
{
    public class Director : MonoBehaviour, IDirector
    {
        private IOutDirectorController directorController;
        private ICharacterController characterController;

        public Director(IOutDirectorController controller)
        {
            directorController = controller;
            CustomStart();
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

        private void CustomStart()
        {
            characterController = RootController.GetControllerByType<ICharacterController>();
            CreateAWaiter();
        }
    }
}