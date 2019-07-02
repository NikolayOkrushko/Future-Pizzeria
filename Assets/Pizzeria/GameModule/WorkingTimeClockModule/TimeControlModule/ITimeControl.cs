using System;

namespace WorkingTimeClockModule.TimeControlModule
{
    public interface ITimeControl
    {
        event Action OnDestroyed;
        event Action OnEndWorkingDay;
        event Action OnPreparetionForClosing;
        event Action<int> OnSecondPassed;
        event Action<int> OnMinutePassed;

        void Init(WorkingTimeClock incomingWorkingTimeClock);
        void StartClock();
    }
}