using System;

namespace AdvertisingModule
{
    public interface IAdvertisingController
    {
        void ShowRewardedADS(Action<string> callback);
    }
}