using Pizzeria.GameModule.CharacterModule;
using UnityEngine;

namespace Pizzeria.GameModule.AdministratorModule
{
    public class Table : MonoBehaviour
    {
        public int TableID { get { return tableID; } }
        public Transform[] VisitorSeat { get { return visitorSeat; } }
        public Transform[] PlacesForWaiter { get { return placesForWaiter; } }
        public Transform PlaceWaiterNearCook { get { return placeWaiterNearCook; } }
        

        [SerializeField] private int tableID;
        [SerializeField] private Transform[] visitorSeat = new Transform[3];
        [SerializeField] private Transform[] placesForWaiter = new Transform[2];
        [SerializeField] private Transform placeWaiterNearCook;


        private ICharacterController currentVisitor;


        public void TakeATable(ICharacterController visitor)
        {
            currentVisitor = visitor;
            // Вызывается метод у Administrator Hall "TakeAnOrder" и передаёт в качестве параметра себя.
        }

        public void ReleaseTheTable()
        {

        }

        public ICharacterController GetVisitor()
        {
            return currentVisitor;
        }
    }
}
