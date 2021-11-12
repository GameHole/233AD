using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.Ad;
using System;
using UnityEngine.UI;

public class MetaAdPluginDemo : MonoBehaviour
{
    const string AppKey = "your appkey"; //Please change it to your App's appkey.

    private bool IsSDKInited = false;

    private Button ShowVideoAdButton;
    private Button ShowInterstitialAdButton;
    private Button ShowBannerAdButton;
    private Text ResultText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start--");

        //SDK初始化操作
        InitSDK();

        ShowVideoAdButton = GameObject.Find("ShowVideoAdButton").GetComponent<Button>();
        ShowInterstitialAdButton = GameObject.Find("ShowInterstitialAdButton").GetComponent<Button>();
        ShowBannerAdButton = GameObject.Find("ShowBannerAdButton").GetComponent<Button>();
        ResultText = GameObject.Find("ResultText").GetComponent<Text>();

        ShowVideoAdButton.onClick.AddListener(ShowVideoAd);
        ShowInterstitialAdButton.onClick.AddListener(ShowInterstitialAd);
        ShowBannerAdButton.onClick.AddListener(ShowBannerAd);
    }

    void InitSDK()
    {
        InitCallback callback = new InitCallback();
        callback.OnInitSuccess += () =>
        {
            Debug.Log("init success result= ok");
            IsSDKInited = true; 
        };
        callback.OnInitFailed += (code, msg) =>
        {
            Debug.Log("init error result=" + code + ",msg=" + msg);
            IsSDKInited = false; 
        };

        MetaAd.InitSdk(GetApplicationContext(), AppKey, callback);
    }

    void ShowVideoAd()
    {

        Debug.Log("call ShowVideoAd method");
        VideoAdCallback videoAdCallback = new VideoAdCallback();

        videoAdCallback.OnAdShow += () => {
            Debug.Log("show video Ad success.");
        };

        videoAdCallback.OnAdClick += () =>
        {
            Debug.Log("click video Ad.");
        };

        videoAdCallback.OnAdComplete += () =>
        {
            Debug.Log("video Ad show completed.");
        };

        videoAdCallback.OnAdReward += () => {
            Debug.Log("Get Ad reward done.");
        };
        //more callbacks see the "VideoAdCallback.cs"

        //video pos id
        int posId = 199000001;
        //call video ad
        MetaAd.ShowVideoAd(posId, videoAdCallback);
    }

    void ShowInterstitialAd()
    {
        Debug.Log("call ShowInterstitialAd method");
        IAdCallback InterstitialAdCallback = new IAdCallback();

        InterstitialAdCallback.OnAdShow += () =>
        {
            Debug.Log("interstitial ad show");
        };

        InterstitialAdCallback.OnAdShowFailed += (code, msg) =>
        {
            Debug.Log("interstitial ad show fail");
        };

        InterstitialAdCallback.OnAdClick += () =>
        {
            Debug.Log("interstitial ad click");
        };

        InterstitialAdCallback.OnAdClose += () =>
        {
            Debug.Log("interstitial ad close");
        };
        //interstitial pos id
        int posId = 199000003;
        MetaAd.ShowInterstitialAd(posId, InterstitialAdCallback);
    }

    void ShowBannerAd()
    {
        Debug.Log("call ShowBannerAd method");
        IAdCallback BannerAdCallback = new IAdCallback();

        BannerAdCallback.OnAdShow += () =>
        {
            Debug.Log("ShowBannerAd ad show");
        };

        BannerAdCallback.OnAdShowFailed += (code, msg) =>
        {
            Debug.Log("ShowBannerAd ad show fail");
        };

        BannerAdCallback.OnAdClick += () =>
        {
            Debug.Log("ShowBannerAd ad click");
        };

        BannerAdCallback.OnAdClose += () =>
        {
            Debug.Log("ShowBannerAd ad close");
        };
        //interstitial pos id
        int posId = 12100322;
        MetaAd.ShowBanner(posId, BannerAdCallback);
    }

    /// <summary>
    /// Gets the current activity running in Unity. This object should be disposed after use.
    /// </summary>
    /// <returns>A wrapped activity object. The AndroidJavaObject should be disposed.</returns>
    public static AndroidJavaObject GetCurrentActivity()
    {
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
    }

    public static AndroidJavaObject GetApplicationContext()
    {
        return GetCurrentActivity().Call<AndroidJavaObject>("getApplicationContext");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
