using System;
namespace AdvertisingModule
{
    public class AdvertisingController : IAdvertisingController
    {
        private AdMobManager adMobManager;


        public AdvertisingController()
        {
            adMobManager = new AdMobManager();
            adMobManager.Init();
        }

        public void ShowRewardedADS(Action<string> callback)
        {
            adMobManager.ShowRewardedADS(callback);

        }
    }
}
