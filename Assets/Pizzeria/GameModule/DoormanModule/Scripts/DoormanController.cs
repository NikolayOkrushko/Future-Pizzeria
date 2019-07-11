using Pizzeria.GameModule.CharacterModule;
using Pizzeria.GameModule.RootModule;
using UnityEngine;

namespace Pizzeria.GameModule.DoormanModule
{
    public class DoormanController : IDoormanController, IOutDoormanController
    {
        private IDoorman doorman;

        
        public void Init()
        {
            RootController.OnModuleAreReady += Start;
        }


        public int GetRatingOfTheHall()
        {
            throw new System.NotImplementedException();
        }



        private void Start()
        {
            RootController.OnModuleAreReady -= Start;

            var doormanPrefab = Resources.Load<GameObject>("Doorman");
            doorman = GameObject.Instantiate<GameObject>(doormanPrefab).GetComponent<Doorman>();
            doorman.Init(this);
        }
    }
}
