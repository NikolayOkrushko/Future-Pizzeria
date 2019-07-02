using System;

namespace WorkingTimeClockModule
{
    public class WorkingTimeClockController : IWorkingTimeClockController, IOutWorkingTimeClockController
    {
        public event Action OnPreparetionForClosing;
        public event Action OnEndWorkingDay;

        private WorkingTimeClock workingTimeClock;


        public WorkingTimeClockController()
        {
            workingTimeClock = new WorkingTimeClock(this);
        }

        public void StartWorkingDay()
        {
            workingTimeClock.StartWorkingDay();
        }

        #region OutInterface
        public void PrepareForClosing()
        {
            if (OnPreparetionForClosing != null)
            {
                OnPreparetionForClosing();
            }
        }

        public void EndedWorkingDay()
        {
            if (OnEndWorkingDay != null)
            {
                OnEndWorkingDay();
            }
        }
        #endregion OutInterface
    }
}
