
namespace Pizzeria.GameModule.DirectorModule
{
    public interface IDirector
    {
        void Init(IOutDirectorController controller);
        void CreateACook();
        void CreateAWaiter();
        void UpgradeACook();
    }
}
