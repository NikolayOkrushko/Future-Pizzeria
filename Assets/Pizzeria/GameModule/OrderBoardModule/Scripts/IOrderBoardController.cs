
using Pizzeria.GameModule.AdministratorModule;
using Pizzeria.GameModule.TableModule;

namespace Pizzeria.GameModule.OrderBoardModule
{
    public interface IOrderBoardController
    {
        void DisplayInformationOnFirstBoard(string message);
        void DisplayInformationOnSecondBoard(string message);
    }
}