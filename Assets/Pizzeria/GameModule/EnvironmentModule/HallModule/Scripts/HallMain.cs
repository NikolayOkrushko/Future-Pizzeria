
using UnityEngine;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;

namespace Pizzeria.GameModule.Environment.HallModule
{
    public class HallMain : MonoBehaviour, IHallMain, IOutHallMain
    {
        [SerializeField] private List<TableUniversal> hallTable = new List<TableUniversal>();

        public List<TableUniversal> GetTable()
        {
            return hallTable;
        }
    }
}
