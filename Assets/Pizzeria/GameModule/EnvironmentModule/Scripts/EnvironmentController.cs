using Pizzeria.GameModule.OrderBoardModule;
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


        public List<Transform> GetExitPlace()
        {
            return environmentMain.GetExitPlace();
        }

        public List<Transform> GetDefaultWaiterPlaces()
        {
            return environmentMain.GetDefaultWaiterPlaces();
        }

        public List<TableUniversal> GetCookTablePlaces()
        {
            return environmentMain.GetCookTablePlaces();
        }

        public OrderBoardController GetOrderBoardController()
        {
            var result = environmentMain.GetOrderBoardController();
            return result;
        }


        private void Start()
        {
            RootController.OnModuleAreReady -= Start;
            environmentMain = new EnvironmentMain(this);
        }
    }
}
