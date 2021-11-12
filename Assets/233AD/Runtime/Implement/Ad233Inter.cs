using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
using System;
using Meta.Ad;

namespace Ad233
{
    public class Ad233Inter : IInterstitialAdAPI,IInitializable
    {
        IAdCallback InterstitialAdCallback;
        public event Action<bool> onClose;

        public void Initialize()
        {
            InterstitialAdCallback = new IAdCallback();
            InterstitialAdCallback.OnAdClose += () =>
            {
                onClose?.Invoke(true);
            };

        }

        public bool isReady() => true;

        public void Show()
        {
#if UNITY_ANDROID
            var set = AScriptableObject.Get<Ad233Setting>();
            MetaAd.ShowInterstitialAd(set.interstitialId, InterstitialAdCallback);
#endif
        }
    }
}
