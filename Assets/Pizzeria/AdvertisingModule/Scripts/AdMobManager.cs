using System;
using UnityEngine;
using GoogleMobileAds.Api;

namespace AdvertisingModule
{
    public class AdMobManager
    {
        public event Action NoInternetConnection;

        public RewardBasedVideoAd rewardedAds;

        private const string appID = "ca-app-pub-1099403244744696~6579173141";
        private const string bannerAdsID = "ca-app-pub-3940256099942544/6300978111";
        private const string interstitialAdsID = "ca-app-pub-3940256099942544/1033173712";
        private const string baseRewardedVideoAdsID = "ca-app-pub-3940256099942544/5224354917";

        private BannerView bannerAds;
        private InterstitialAd interstitialAds;

        private Action<string> callbackAndrew;


        public void Init()
        {
            MobileAds.Initialize(appID);
            HandleBannerAdsEvents(true);

            
        }

        public void DeInit()
        {
            HandleBannerAdsEvents(false);
        }

        public void ShowRewardedADS(Action<string> callback)
        {
            callbackAndrew = callback;
            rewardedAds.Show();
        }


        #region BANNER
        public void RequestBanner()
        {
            BuildBanner();
        }

        public void DisplayBanner()
        {
            bannerAds.Show();
        }

        public void DestroyBanner()
        {
            bannerAds.Destroy();
        }
        #endregion

        #region INTERSTITIAL
        public void RequestInterstitialADS()
        {
            BuildInterstitialAds();
        }

        public void DisplayInterstitialAds()
        {
            if (interstitialAds.IsLoaded())
            {
                interstitialAds.Show();
            }
        }

        public void DestroyInterstitial()
        {
            interstitialAds.Destroy();
        }
        #endregion

        #region REWARDED_VIDEO
        public void RequestRewardedVideo()
        {
            BuildBaseRewardedVideoAds();
        }

        public void DisplayRewardedVideo()
        {
            if (rewardedAds.IsLoaded())
            {
                rewardedAds.Show();
            } 
        }
        #endregion





        public void HandleOnAdLoaded(object sender, EventArgs args)
        {
            DisplayBanner();
        }

        public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            BuildBanner();
        }

        public void HandleOnAdOpened(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdOpened event received");
        }

        public void HandleOnAdClosed(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdClosed event received");
        }

        public void HandleOnAdLeavingApplication(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleAdLeavingApplication event received");
        }


        private void BuildBanner()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
      string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
      string adUnitId = "unexpected_platform";
#endif

            bannerAds = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

            AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
            bannerAds.LoadAd(adRequest);
        }

        private void BuildInterstitialAds()
        {
            interstitialAds = new InterstitialAd(interstitialAdsID);

            AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
            interstitialAds.LoadAd(adRequest);
        }

        private void BuildBaseRewardedVideoAds()
        {
            rewardedAds = RewardBasedVideoAd.Instance;

            AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
            rewardedAds.LoadAd(adRequest, baseRewardedVideoAdsID);
        }

        private void HandleBannerAdsEvents(bool subscribe)
        {
            if (subscribe)
            {
                bannerAds.OnAdLoaded += HandleOnAdLoaded;
                bannerAds.OnAdFailedToLoad += HandleOnAdFailedToLoad;
                bannerAds.OnAdOpening += HandleOnAdOpened;
                bannerAds.OnAdClosed += HandleOnAdClosed;
                bannerAds.OnAdLeavingApplication += HandleOnAdLeavingApplication;
            }
            else
            {
                bannerAds.OnAdLoaded -= HandleOnAdLoaded;
                bannerAds.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
                bannerAds.OnAdOpening -= HandleOnAdOpened;
                bannerAds.OnAdClosed -= HandleOnAdClosed;
                bannerAds.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
            }
        }
    }
}