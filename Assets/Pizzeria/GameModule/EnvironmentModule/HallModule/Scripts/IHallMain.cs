using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.Environment.HallModule
{
    public interface IHallMain
    {
        void Init();
        List<TableUniversal> GetTable();
        List<Transform> GetExitPlaces();
        List<Transform> GetDefaultWaiterPlaces();
        List<TableUniversal> GetCookTablePlaces();
    }
}
