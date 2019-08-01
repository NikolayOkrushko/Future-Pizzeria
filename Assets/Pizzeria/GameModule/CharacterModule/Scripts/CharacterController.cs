using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.CharacterModule.States;
using Pizzeria.GameModule.RootModule;
using Pizzeria.GameModule.TableModule;
using System;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule
{
    public enum CharacterConteiner
    {
        Visitor,
        Waiter,
        Cook
    }

    public class CharacterController : ICharacterController
    {
        public IAdministratorController AdministratorController { get; private set; }
        public event Action OnOrderSelected;
        public event Action OnOrderPlaced;
        public event Action OnCookTaketheOrder;

        private ICook cook;
        private IVisitor visitor;
        private IWaiter waiter;
        private CharacterConteiner characterConteiner;



        public void Init()
        {
            RootController.OnModuleAreReady += Start;
        }


        public void CreateCharacter(CharacterConteiner conteiner)
        {
            characterConteiner = conteiner;

            switch (characterConteiner)
            {
                case CharacterConteiner.Visitor:
                    var visitorPrefab = Resources.Load<GameObject>("VisitorConteiner");
                    visitor = GameObject.Instantiate<GameObject>(visitorPrefab, new Vector3(16, 2, 16), Quaternion.identity).AddComponent<Visitor>();
                    visitor.Init(this);
                    break;
                case CharacterConteiner.Waiter:
                    var waiterPrefab = Resources.Load<GameObject>("WaiterConteiner");
                    waiter = GameObject.Instantiate<GameObject>(waiterPrefab, new Vector3(16, 1.5f, 16), Quaternion.identity).AddComponent<Waiter>();
                    waiter.Init(this);
                    break;
                case CharacterConteiner.Cook:
                    var cookPrefab = Resources.Load<GameObject>("CookConteiner");
                    cook = GameObject.Instantiate<GameObject>(cookPrefab, new Vector3(16, 1.5f, 16), Quaternion.identity).AddComponent<Cook>();
                    cook.Init(this);
                    break;
            }
        }


        #region Visitor
        public void OrderSelected()
        {
            if (OnOrderSelected != null)
            {
                OnOrderSelected();
            }
        }


        public TableUniversal GetFreeTable()
        {
            var table = AdministratorController.GetFreeVisitorTable();
            return table;
        }

        public Transform[] GetExitPlace()
        {
            return AdministratorController.GetExitPlaces().ToArray();
        }

        public void LeaveFeedback(bool feedback)
        {
            // вызватить у администратора метод оставить отзыв.
        }
        #endregion

        #region Waiter
        public TableUniversal GetVisitorWhoNeedTakeOrder()
        {
            var result = AdministratorController.GetVisitorWhoNeedTakeOrder();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public ReadyOrder GetTheOrderWhichBringTheVisitor()
        {
            var result = AdministratorController.GetTheOrderWhichBringTheVisitor();
            return result;
        }

        public Transform[] GetPlaceToWait()
        {
            var waiterPlaces = AdministratorController.GetDefaultWaiterPlaces().ToArray();
            return waiterPlaces;
        }

        public TableUniversal[] GetCookTablePlace()
        {
            var result = AdministratorController.GetCookTablePlace().ToArray();
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public void AddOrderToQueueForCooking(TableUniversal visitorTable)
        {
            AdministratorController.AddOrderToQueueForCooking(visitorTable);
            if (OnCookTaketheOrder != null)
            {
                OnCookTaketheOrder();
            }
        }
        #endregion

        #region Cook

        public void RemoveCookTable(TableUniversal cookTable)
        {
            AdministratorController.RemoveCookTable(cookTable);
        }

        public TableUniversal TakeOrderTheNeedToPrepare()
        {
            var result = AdministratorController.GetOrderNeedToPrepared();
            return result;
        }

        #endregion

        private void Start()
        {
            RootController.OnModuleAreReady -= Start;
            AdministratorController = RootController.GetControllerByType<IAdministratorController>();
        }
    }
}
