using Pizzeria.GameModule.CharacterModule;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pizzeria.GameModule.TableModule
{
    public class TableUniversal : MonoBehaviour
    {
        public event Action OnWaiterCome;
        public int TableID { get { return tableID; } }

        [SerializeField] private int tableID;
        [SerializeField] private List<Transform> usualPlaces = new List<Transform>();
        [SerializeField] private List<Transform> waiterPlaces = new List<Transform>();

        private ICharacterController currentVisitor;


        public void TakeATable(ICharacterController visitor)
        {
            currentVisitor = visitor;
            // Вызывается метод у Administrator Hall "TakeAnOrder" и передаёт в качестве параметра себя.
        }

        public void CallTheWaiter()
        {
            // стол обращается к админу что бы тот записал его в очередь
        }

        public void ReleaseTheTable()
        {

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

    }
}

