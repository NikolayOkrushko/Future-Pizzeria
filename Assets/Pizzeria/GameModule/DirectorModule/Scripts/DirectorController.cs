

using Pizzeria.GameModule.CharacterModule;
using Pizzeria.GameModule.RootModule;
using UnityEngine;

namespace Pizzeria.GameModule.DirectorModule
{
    public class DirectorController : IDirectorController, IOutDirectorController
    {
        private IDirector director;

        public void Init()
        {
            RootController.OnModuleAreReady += Start;
        }

        public void BuyAWaiter()
        {
            director.CreateAWaiter();
        }

        public void BuyACook()
        {
            director.CreateACook();
        }

        public void UpgradeACook()
        {
            director.UpgradeACook();
        }


        private void Start()
        {
            RootController.OnModuleAreReady -= Start;

            var directorPrefab = Resources.Load<GameObject>("HallDirector");
            director = GameObject.Instantiate<GameObject>(directorPrefab).GetComponent<Director>();
            director.Init(this);
        }
    }
}
