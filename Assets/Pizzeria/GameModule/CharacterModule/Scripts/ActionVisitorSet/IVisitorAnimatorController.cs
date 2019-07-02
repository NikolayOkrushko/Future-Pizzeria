using System;

namespace Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet
{
    public interface IVisitorAnimatorController
    {
        event Action OnAnimationEnd;

        void AnimationEnd();
    }
}