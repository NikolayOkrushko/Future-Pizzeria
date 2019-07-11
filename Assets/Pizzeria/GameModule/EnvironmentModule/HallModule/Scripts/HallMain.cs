using UnityEngine;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;
using UnityEngine.AI;

namespace Pizzeria.GameModule.Environment.HallModule
{
    public class HallMain : MonoBehaviour, IHallMain, IOutHallMain
    {
        [SerializeField] private List<TableUniversal> hallTable = new List<TableUniversal>();
        [SerializeField] private List<Transform> exitPlace = new List<Transform>();
        [SerializeField] private List<Transform> defaultWaiterPlaces = new List<Transform>();
        [SerializeField] private List<TableUniversal> cookTablePlace = new List<TableUniversal>();
        [SerializeField] private NavMeshSurface hallSurface;



        public void Init()
        {
            hallSurface.BuildNavMesh();
        }

        public List<TableUniversal> GetTable()
        {
            return hallTable;
        }

        public List<Transform> GetExitPlaces()
        {
            return exitPlace;
        }

        public List<Transform> GetDefaultWaiterPlaces()
        {
            return defaultWaiterPlaces;
        }

        public List<TableUniversal> GetCookTablePlaces()
        {
            return cookTablePlace;
        }
    }
}
