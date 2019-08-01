

namespace Pizzeria.GameModule.OrderBoardModule.UIBorderModule
{
    public interface IUIBoard
    {
        void DisplayOrderMustBePrepared(int tableID);
        void RemoveFromDisplayOrderMustBePrepared(int tableID);
        void DisplayReadyOrder(int tableID);
        void RemoveFromDisplayReadyOrder(int tableID);
    }
}
