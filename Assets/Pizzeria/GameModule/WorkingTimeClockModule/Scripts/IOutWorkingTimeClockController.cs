
namespace WorkingTimeClockModule
{
    public interface IOutWorkingTimeClockController
    {
        void PrepareForClosing();
        void EndedWorkingDay();
    }
}