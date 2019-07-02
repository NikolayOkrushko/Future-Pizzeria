using CharacterModule.Test;
using System;
using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet
{
    public class VisitorAnimatorController : MonoBehaviour, IVisitorAnimatorController
    {
        public event Action OnAnimationEnd;

        private RootCharacterControllerTest rootController;


        public void AnimationEnd()
        {
            if (OnAnimationEnd != null)
            {
                OnAnimationEnd();
            }
        }
    }
}
