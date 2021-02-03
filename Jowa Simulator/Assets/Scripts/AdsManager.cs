using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public event EventHandler<AdFinishedEventArgs> OnAdDone;
    public string GameID
    {
        get
        {
#if UNITY_ANDROID
            return "3998651";

#elif UNITY_IOS
            return "3998650";

#endif
        }
    }

    public const string InterstitialAd = "video";
    public const string RewardedAd = "rewardedVideo";
    public const string BannerAd = "BannerAd";

    public GameObject sharePanel;

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GameID, true);
    }

    void Update()
    {
        if (sharePanel.activeSelf)
        {
            DisplayBannerAd();
        }
    }

    IEnumerator LoadBannerAd()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(BannerAd);
    }

    public void DisplayBannerAd()
    {
        StartCoroutine(LoadBannerAd());
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log($"Done loading {placementId}");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"Ads error: {message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log($"Started Ad: {placementId}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (OnAdDone != null)
        {
            AdFinishedEventArgs args = new AdFinishedEventArgs(placementId, showResult);
            OnAdDone(this, args);
        }
    }

    public void DisplayRewardedAd()
    {
        if (Advertisement.IsReady(RewardedAd))
        {
            Advertisement.Show(RewardedAd);
        }
        else
        {
            Debug.Log("No Ads!");
        }
    }
}
