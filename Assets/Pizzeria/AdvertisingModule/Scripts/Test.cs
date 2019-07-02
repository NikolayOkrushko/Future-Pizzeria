using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private AdvertisingModule.IAdvertisingController advertisingController;

    private void Awake()
    {
        advertisingController = new AdvertisingModule.AdvertisingController();

        //advertisingController.ShowRewardedADS();
    }
}
