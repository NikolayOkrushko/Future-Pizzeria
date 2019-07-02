using UnityEngine;

namespace WorkingTimeClockModule.ClockUIModule
{
    public class ClockUI : MonoBehaviour, IClockUI
    {
        [SerializeField] private Transform secondHand;
        [SerializeField] private Transform minuteHand;

        private WorkingTimeClock workingTimeClock;
        private Vector3 currentHand = Vector3.zero;

        public void Init(WorkingTimeClock incomingWorkingTimeClock)
        {
            workingTimeClock = incomingWorkingTimeClock;

            workingTimeClock.timeControl.OnSecondPassed += ChangeTheSecondHand;
            workingTimeClock.timeControl.OnMinutePassed += ChangeTheMinuteHand;
        }


        private void ChangeTheSecondHand(int secondCount)
        {
            Debug.Log($"secondCount = {secondCount}");
            currentHand.z = -secondCount * 6;
            secondHand.localEulerAngles = currentHand;
        }

        private void ChangeTheMinuteHand(int minuteCount)
        {
            currentHand.z = -minuteCount * 6;
            minuteHand.localEulerAngles = currentHand;
        }

        private void OnDestroy()
        {
            workingTimeClock.timeControl.OnSecondPassed -= ChangeTheSecondHand;
            workingTimeClock.timeControl.OnMinutePassed -= ChangeTheMinuteHand;
        }
    }
}
