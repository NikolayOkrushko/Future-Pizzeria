using Pizzeria.GameModule.TableModule;

namespace Pizzeria.GameModule.CharacterModule.States
{
    public interface ICook
    {
        TableUniversal cookTable { get; }
        void Init(ICharacterController characterController);
        void Execute();
    }
}