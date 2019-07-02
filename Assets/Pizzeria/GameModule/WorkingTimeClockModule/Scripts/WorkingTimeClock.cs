using WorkingTimeClockModule.TimeControlModule;
using WorkingTimeClockModule.ClockUIModule;
using System;
using UnityEngine;

namespace WorkingTimeClockModule
{
    public class WorkingTimeClock
    {
        public ITimeControl timeControl;
        public IClockUI clockUI;

        private IOutWorkingTimeClockController workingTimeClockController;


        public WorkingTimeClock(IOutWorkingTimeClockController controller)
        {
            workingTimeClockController = controller;
            timeControl = new GameObject("TimeControl").AddComponent<TimeControl>();

            timeControl.OnPreparetionForClosing += workingTimeClockController.PrepareForClosing;
            timeControl.OnEndWorkingDay += workingTimeClockController.EndedWorkingDay;
            timeControl.OnDestroyed += OnDisable;

            var prefabClockUI = Resources.Load<GameObject>("ClockUI");
            clockUI = GameObject.Instantiate<GameObject>(prefabClockUI).GetComponent<IClockUI>();
            clockUI.Init(this);
        }


        public void StartWorkingDay()
        {
            timeControl.StartClock();
        }


        private void OnDisable()
        {
            timeControl.OnPreparetionForClosing -= workingTimeClockController.PrepareForClosing;
            timeControl.OnEndWorkingDay -= workingTimeClockController.EndedWorkingDay;
            timeControl.OnDestroyed -= OnDisable;
        }
    }
}