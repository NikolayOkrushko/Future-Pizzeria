using UnityEngine;
using WorkingTimeClockModule;
using WorkingTimeClockModule.TimeControlModule;
namespace WorkingTimeClockModule.Test
{
    public class Test : MonoBehaviour
    {
        private IWorkingTimeClockController workingTimeClockController;

        void Start()
        {
            workingTimeClockController = new WorkingTimeClockController();
            workingTimeClockController.OnPreparetionForClosing += PreparetionForClosingTest;
            workingTimeClockController.OnEndWorkingDay += EndWorkingDayTest;

            workingTimeClockController.StartWorkingDay();
        }


        private void PreparetionForClosingTest()
        {
            Debug.Log("PreparetionForClosingTest called");
        }

        private void EndWorkingDayTest()
        {
            Debug.Log("EndWorkingDayTest called");
        }

    }
}
