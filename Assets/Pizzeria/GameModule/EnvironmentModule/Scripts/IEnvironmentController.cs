using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.OrderBoardModule;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.EnvironmentModule
{
    public interface IEnvironmentController
    {
        void Init();
        List<TableUniversal> GetTables();
        List<Transform> GetExitPlace();
        List<Transform> GetDefaultWaiterPlaces();
        List<TableUniversal> GetCookTablePlaces();
        OrderBoardController GetOrderBoardController();
    }
}