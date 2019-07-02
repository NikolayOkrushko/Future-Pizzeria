using UnityEngine;
using Pizzeria.GameModule.Environment.HallModule;
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;

namespace Pizzeria.GameModule.EnvironmentModule
{
    public class EnvironmentMain
    {
        private IOutEnvironmentController environmentController;
        private IHallMain hallMain;

        private GameObject hallPrefab;


        public EnvironmentMain(IOutEnvironmentController controller)
        {
            environmentController = controller;

            var hallPrefab = Resources.Load<GameObject>("Hall");
            hallMain = GameObject.Instantiate<GameObject>(hallPrefab).GetComponent<IHallMain>();
        }


        public List<TableUniversal> GetTables()
        {
            return hallMain.GetTable();
        }

    }
}
