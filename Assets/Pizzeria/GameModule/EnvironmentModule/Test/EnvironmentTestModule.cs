
using Pizzeria.GameModule.Environment.HallModule;
using Pizzeria.GameModule.EnvironmentModule;
using Pizzeria.GameModule.AdministratorModule;
using UnityEngine;
using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;

namespace Pizzeria.GameModule.Environment.TestModule
{
    public class EnvironmentTestModule : MonoBehaviour
    {
        [SerializeField] private Transform respPositionCharacter;
        private List<TableUniversal> tablesTest;

        private IHallMain hallMain;

        private void Start()
        {
            var hallPrefab = Resources.Load<GameObject>("Hall");
            hallMain = GameObject.Instantiate<GameObject>(hallPrefab).GetComponent<IHallMain>();
            FillTables();


            var prefabCharacter = Resources.Load<GameObject>("CharacterConteiner");
            //characterController = Instantiate(prefabCharacter, respPositionCharacter).AddComponent<CharacterControllerTEST>();
            //characterController.GetTable(tablesTest);

        }


        private void FillTables()
        {
            var tables = hallMain.GetTable();

            foreach (var table in tables)
            {
                tablesTest = tables;
            }
        }
    }
}
