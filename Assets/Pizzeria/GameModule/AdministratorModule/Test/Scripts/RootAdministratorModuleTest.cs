using Pizzeria.GameModule.TableModule;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.AdministratorModule.Test
{
    public class RootAdministratorModuleTest : MonoBehaviour
    {
        [SerializeField] private List<TableUniversal> tables = new List<TableUniversal>();
        private IAdministratorController administratorController;

        void Start()
        {
            administratorController = new AdministratorController();
        }

        public List<TableUniversal> GetFreeTable()
        {
            return tables;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (administratorController.GetFreeVisitorTable() != null)
                {
                    var result = administratorController.GetFreeVisitorTable();
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                administratorController.CallTheWaiter(tables[0]);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                administratorController.AddOrderToQueueForCooking(tables[1]);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                var table = administratorController.GetVisitorWhoNeedTakeOrder();
                if (table != null)
                {
                    var result = table;
                    Debug.Log($"У этого стола нужно принять заказ { result.TableID}");
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                var result = administratorController.GetTheOrderWhichBringTheVisitor();
                Debug.Log($"Этот заказ нужно вынести посетителю { result.VisitorTable()}");
            }


            if (Input.GetKeyDown(KeyCode.A))
            {
                var result = administratorController.GetOrderNeedToPrepared();
                Debug.Log($"за этот стол нужно приготовить заказ посетителю { result.TableID}");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                //administratorController.AddOrderPrepared(readyOrder);
                //Debug.Log("Передаём готовый  заказ", readyOrder);
            }
        }
    }
}
