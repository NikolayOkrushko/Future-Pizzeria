
using GameModule.GlobalModule.GlobalUpdate;
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.CharacterModule;
using Pizzeria.GameModule.TableModule;
using UnityEngine;

namespace CharacterModule.Test
{
    public class RootCharacterControllerTest : MonoBehaviour
    {
        public IGlobalUpdate GlobalUpdate;
        public ICharacterController CharacterController;
        [SerializeField] private TableUniversal table;
        [SerializeField] private CharacterConteiner characterConteiner;
        [SerializeField] Transform[] exitPlace;
        [SerializeField] private TableUniversal[] cookTables = new TableUniversal[3];
        [SerializeField] private Transform[] defaultWaitersPlace;
        private ReadyOrder readyOrder;

        void Start()
        {
            readyOrder = new ReadyOrder(table, cookTables[1]);

            GlobalUpdate = new GameObject("Global Update").AddComponent<GlobalUpdate>();

        }

        public TableUniversal GetTable()
        {
            return table;
        }


        public ReadyOrder GetReadyOrder()
        {
            return readyOrder;
        }

        public Transform[] GetExitPlace()
        {
            return exitPlace;
        }

        public TableUniversal[] CookTablePlaces()
        {
            return cookTables;
        }

        public Transform[] GetDefaultWaiterPlaces()
        {
            return defaultWaitersPlace;
        }

    }
}
