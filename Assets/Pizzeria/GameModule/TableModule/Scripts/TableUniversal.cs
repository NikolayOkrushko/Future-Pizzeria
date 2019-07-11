using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.CharacterModule;
using Pizzeria.GameModule.RootModule;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.TableModule
{
    public class TableUniversal : MonoBehaviour
    {
        public event Action OnWaiterCome;
        public event Action OnFoodOnTheTable;
        public int TableID { get { return tableID; } }

        [SerializeField] private int tableID;
        [SerializeField] private List<Transform> usualPlaces = new List<Transform>();
        [SerializeField] private List<Transform> waiterPlaces = new List<Transform>();
        private IAdministratorController administratorController;

        private ICharacterController currentVisitor;


        public void TakeATable(ICharacterController visitor)
        {
            currentVisitor = visitor;
            administratorController = RootController.GetControllerByType<IAdministratorController>();
        }

        public void CallTheWaiter()
        {
            administratorController.CallTheWaiter(this);
        }

        public void ReleaseTheTable()
        {
            administratorController.RemoveBusyTable(this);
        }

        public ICharacterController GetVisitor()
        {
            if (OnWaiterCome != null)
            {
                OnWaiterCome();
            }

            return currentVisitor;
        }

        public Transform[] GetVisitorPlace()
        {
            return usualPlaces.ToArray();
        }

        public Transform[] GetCookPlace()
        {
            return usualPlaces.ToArray();
        }

        public Transform[] GetWaiterPlace()
        {
            return waiterPlaces.ToArray();
        }

        public void FoodOnTheTable()
        {
            if (OnFoodOnTheTable != null)
            {
                OnFoodOnTheTable();
            }
        }

    }
}

