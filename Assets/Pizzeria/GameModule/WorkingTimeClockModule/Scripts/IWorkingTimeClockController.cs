using System;

namespace WorkingTimeClockModule
{
    public interface IWorkingTimeClockController
    {
        event Action OnEndWorkingDay;
        event Action OnPreparetionForClosing;

        void StartWorkingDay();
    }
}