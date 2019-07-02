using Pizzeria.GameModule.CharacterModule.States.ActionVisitorSet;
using Pizzeria.GameModule.TableModule;

namespace Pizzeria.GameModule.CharacterModule.States
{
    public interface IVisitor
    {
        IVisitorAnimatorController visitorAnimatorController { get; }
        void Init(ICharacterController controller);
        void Execute();
    }
}
