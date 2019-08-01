using UnityEngine;
using Pizzeria.GameModule.Environment.HallModule;
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;
using Pizzeria.GameModule.OrderBoardModule;

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
            hallMain.Init();
        }


        public List<TableUniversal> GetTables()
        {
            return hallMain.GetTable();
        }

        public List<Transform> GetExitPlace()
        {
            return hallMain.GetExitPlaces();
        }

        public List<Transform> GetDefaultWaiterPlaces()
        {
            return hallMain.GetDefaultWaiterPlaces();
        }

        public List<TableUniversal> GetCookTablePlaces()
        {
            return hallMain.GetCookTablePlaces();
        }

        public OrderBoardController GetOrderBoardController()
        {
            var result = hallMain.GetOrderBoardController();
            return result;
        }
    }
}
