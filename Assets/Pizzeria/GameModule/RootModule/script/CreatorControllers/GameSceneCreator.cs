using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.CharacterModule;
using Pizzeria.GameModule.DirectorModule;
using Pizzeria.GameModule.DoormanModule;
using Pizzeria.GameModule.EnvironmentModule;
using System;
using System.Collections.Generic;

namespace Pizzeria.GameModule.RootModule.ControllerCreators
{
    public class GameSceneCreator : IControllerCreator
    {
        public Dictionary<Type, object> Execute()
        {
            return CreateNeededControllers();
        }

        private Dictionary<System.Type, object> CreateNeededControllers()
        {
            var moduleControllers = new Dictionary<System.Type, object>();

            IEnvironmentController EnvironmentController = new EnvironmentController();
            moduleControllers.Add(typeof(IEnvironmentController), EnvironmentController);
            EnvironmentController.Init();

            IAdministratorController AdministratorController = new AdministratorController();
            moduleControllers.Add(typeof(IAdministratorController), AdministratorController);
            AdministratorController.Init();

            ICharacterController CharacterController = new Pizzeria.GameModule.CharacterModule.CharacterController();
            moduleControllers.Add(typeof(ICharacterController), CharacterController);
            CharacterController.Init();

            IDirectorController DirectorController = new DirectorController();
            moduleControllers.Add(typeof(IDirectorController), DirectorController);
            DirectorController.Init();

            IDoormanController DoormanController = new DoormanController();
            moduleControllers.Add(typeof(IDoormanController), DoormanController);
            DoormanController.Init();

            return moduleControllers;
        }
    }
}
