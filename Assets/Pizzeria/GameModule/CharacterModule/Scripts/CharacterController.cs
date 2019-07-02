using CharacterModule.Test;
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.CharacterModule.States;
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

    public class CharacterController : ICharacterController, IOutCharacterController
    {
        public RootCharacterControllerTest RootCharacterModuleTest { get; private set; }
        public event Action OnOrderSelected;

        private ICook cook;
        private IVisitor visitor;
        private IWaiter waiter;
        private CharacterConteiner characterConteiner;



        public void CreateCharacter(CharacterConteiner conteiner)
        {
            characterConteiner = conteiner;

            switch (characterConteiner)
            {
                case CharacterConteiner.Visitor:
                    var visitorPrefab = Resources.Load<GameObject>("VisitorConteiner");
                    visitor = GameObject.Instantiate<GameObject>(visitorPrefab).AddComponent<Visitor>();
                    visitor.Init(this);
                    break;
                case CharacterConteiner.Waiter:
                    var waiterPrefab = Resources.Load<GameObject>("WaiterConteiner");
                    waiter = GameObject.Instantiate<GameObject>(waiterPrefab).AddComponent<Waiter>();
                    waiter.Init(this);
                    break;
                case CharacterConteiner.Cook:
                    var cookPrefab = Resources.Load<GameObject>("CookConteiner");
                    cook = GameObject.Instantiate<GameObject>(cookPrefab).AddComponent<Cook>();
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
            var table = RootCharacterModuleTest.GetTable();
            return table;
        }

        public Transform[] GetExitPlace()
        {
            return RootCharacterModuleTest.GetExitPlace();
        }

        public void LeaveFeedback(bool feedback)
        {
            // вызватить у администратора метод оставить отзыв.
        }
        #endregion

        #region Waiter
        public TableUniversal GetVisitorWhoNeedTakeOrder()
        {
            //return RootCharacterModuleTest.GetTable();
            return null;
        }

        public ReadyOrder GetTheOrderWhichBringTheVisitor()
        {
            var result = RootCharacterModuleTest.GetReadyOrder();
            return result;
            //return null;
        }

        public Transform[] GetPlaceToWait()
        {
            return RootCharacterModuleTest.GetDefaultWaiterPlaces();
        }

        public TableUniversal[] GetCookTablePlace()
        {
            return RootCharacterModuleTest.CookTablePlaces();
        }

        public void AddOrderToQueueForCooking(TableUniversal visitorTable)
        {
            Debug.Log(visitorTable.TableID);
        }
        #endregion

        #region Cook
        public TableUniversal TakeOrderTheNeedToPrepare()
        {
            return null;
        }

        public TableUniversal[] GetCookPlace()
        {
            return null;
        }


        #endregion
    }
}
