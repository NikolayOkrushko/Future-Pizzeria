using CharacterModule.Test;
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;
using System;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule
{
    public interface ICharacterController
    {
        IAdministratorController AdministratorController { get; }
        event Action OnOrderSelected;
        event Action OnOrderPlaced;
        event Action OnCookTaketheOrder;
        void Init();
        void CreateCharacter(CharacterConteiner characterConteiner);
        #region Visitor
        void OrderSelected();
        TableUniversal GetFreeTable();
        void LeaveFeedback(bool feedback);
        Transform[] GetExitPlace();
        #endregion

        #region Waiter
        TableUniversal GetVisitorWhoNeedTakeOrder();
        ReadyOrder GetTheOrderWhichBringTheVisitor();
        Transform[] GetPlaceToWait();
        TableUniversal[] GetCookTablePlace();
        void AddOrderToQueueForCooking(TableUniversal visitorTable);
        void RemoveCookTable(TableUniversal cookTable);
        #endregion

        #region Cook
        TableUniversal TakeOrderTheNeedToPrepare();
        #endregion
    }
}
