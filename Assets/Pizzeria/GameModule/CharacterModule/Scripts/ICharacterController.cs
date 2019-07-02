using CharacterModule.Test;
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;
using System;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule
{
    public interface ICharacterController
    {
        RootCharacterControllerTest RootCharacterModuleTest { get; }
        event Action OnOrderSelected;
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
        #endregion

        #region Cook
        TableUniversal TakeOrderTheNeedToPrepare();
        TableUniversal[] GetCookPlace();
        #endregion
    }
}
