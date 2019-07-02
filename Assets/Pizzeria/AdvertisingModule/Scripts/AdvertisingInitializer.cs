using System;
using UnityEngine;
using GoogleMobileAds.Api;

namespace AdvertisingModule
{
    public class AdvertisingInitializer
    {
        private const string appID = "ca-app-pub-1099403244744696~6579173141";
        private const string baseRewardedVideoAdsID = "ca-app-pub-3940256099942544/5224354917"; 

        private RewardBasedVideoAd rewardBasedVideoAd;


        public void Init()
        {
            MobileAds.Initialize(appID);
            HandleBannerAdsEvents(true);
        }

        public void DeInit()
        {
            HandleBannerAdsEvents(false);
        }

        private void ShowAdvertising()
        {
            rewardBasedVideoAd = RewardBasedVideoAd.Instance;

            AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
            rewardBasedVideoAd.LoadAd(adRequest, baseRewardedVideoAdsID);

            if (rewardBasedVideoAd.IsLoaded())
            {
                rewardBasedVideoAd.Show();
            }
        }

        #region HandlesMethod
        private void AdvertisementLoaded(object sender, EventArgs args)
        {
            Debug.Log("Реклама успешно загружена");
        }

        private void AdvertisementCouldNotLoaded(object sender, EventArgs args)
        {
            Debug.Log("Реклама не смогла загрузится");
        }

        private void AdvertisingWindowPressed(object sender, EventArgs args)
        {
            Debug.Log("На рекламное окно совершено нажатие");
        }

        private void AdvertisingWindowClosed(object sender, EventArgs args)
        {
            Debug.Log("Рекламное окно закрыли");
        }

        private void RewardForViewing(object sender, EventArgs args)
        {
            Debug.Log("Юзер не досмотрел рекламу");
        }
        #endregion

        #region Subscribe and unsubscribe
        private void HandleBannerAdsEvents(bool subscribe)
        {
            if (subscribe)
            {
                rewardBasedVideoAd.OnAdLoaded += AdvertisementLoaded;
                rewardBasedVideoAd.OnAdFailedToLoad += AdvertisementCouldNotLoaded;
                rewardBasedVideoAd.OnAdOpening += AdvertisingWindowPressed;
                rewardBasedVideoAd.OnAdClosed += AdvertisingWindowClosed;
                rewardBasedVideoAd.OnAdCompleted += RewardForViewing;
            }
            else
            {
                rewardBasedVideoAd.OnAdLoaded -= AdvertisementLoaded;
                rewardBasedVideoAd.OnAdFailedToLoad -= AdvertisementCouldNotLoaded;
                rewardBasedVideoAd.OnAdOpening -= AdvertisingWindowPressed;
                rewardBasedVideoAd.OnAdClosed -= AdvertisingWindowClosed;
                rewardBasedVideoAd.OnAdCompleted -= RewardForViewing;
            }
        }
        #endregion
    }





}
