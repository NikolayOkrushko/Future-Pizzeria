using System;
using UnityEngine;
using WorkingTimeClockModule;

namespace WorkingTimeClockModule.TimeControlModule
{
    public class TimeControl : MonoBehaviour, ITimeControl
    {
        public event Action<int> OnSecondPassed;
        public event Action<int> OnMinutePassed;
        public event Action OnEndWorkingDay;
        public event Action OnPreparetionForClosing;
        public event Action OnDestroyed;

        private const int workingDayDuration = 12;
        private const int preparetionTimeForClosing = 10;
        private const string secondPassedMethod = "SecondPassed";

        private int seconds;
        private int minutes;
        private int passedTime;


        private WorkingTimeClock workingTimeClock;


        public void Init(WorkingTimeClock incomingWorkingTimeClock)
        {
            workingTimeClock = incomingWorkingTimeClock;
        }

        public void StartClock()
        {
            seconds = 0;
            minutes = 0;
            InvokeRepeating(secondPassedMethod, 1f, 1f);

            Debug.Log("TimeControl: StartClock");
        }


        private void SecondPassed()
        {
            if (OnSecondPassed != null)
            {
                OnSecondPassed(seconds);
            }

            Debug.Log($"TimeControl: seconds = {seconds}");
            CulculateCurrentTime();
        }

        private void CulculateCurrentTime()
        {
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;

                if (OnMinutePassed != null)
                {
                    OnMinutePassed(minutes);
                }

                if (minutes == preparetionTimeForClosing)
                {
                    if (OnPreparetionForClosing != null)
                    {
                        OnPreparetionForClosing();
                    }
                }


                if (minutes == workingDayDuration)
                {
                    minutes = 0;
                    seconds = 0;
                    CancelInvoke(secondPassedMethod);

                    if (OnEndWorkingDay != null)
                    {
                        OnEndWorkingDay();
                    }
                }
            }
        }

        private void OnDestroy()
        {
            if (OnDestroyed != null)
            {
                OnDestroyed();
            }
        }
    }
}