
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.RootModule;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.EnvironmentModule
{
    public class EnvironmentController : IEnvironmentController, IOutEnvironmentController
    {
        private EnvironmentMain environmentMain;


        public void Init()
        {
            RootController.OnModuleAreReady += Start;
        }


        public List<TableUniversal> GetTables()
        {
            return environmentMain.GetTables();
        }

        private void Start()
        {
            RootController.OnModuleAreReady -= Start;
            environmentMain = new EnvironmentMain(this);
        }
    }
}
