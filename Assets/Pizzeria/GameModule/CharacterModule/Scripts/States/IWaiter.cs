using UnityEngine;

namespace Pizzeria.GameModule.CharacterModule.States
{
    public interface IWaiter
    {
        Transform WaitPointWaiter { get; }
        void Init(ICharacterController controller);
    }
}