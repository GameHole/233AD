using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
using System;
using Meta.Ad;

namespace Ad233
{
    public class Ad233Banner : IBannerAd,IInitializable
    {
        IAdCallback BannerAdCallback;
        public Action<int> onClose { get; set ; }
        public Action onHide { get; set; }

        public event Action onShow;

        public void Hide()
        {
            onHide?.Invoke();
            MetaAd.ShowBanner(-1, BannerAdCallback);
        }

        public void Initialize()
        {
            BannerAdCallback = new IAdCallback();

            BannerAdCallback.OnAdShow += () =>
            {
                onShow?.Invoke();
            };

            
            BannerAdCallback.OnAdClose += () =>
            {
                onClose?.Invoke(0);
                onHide?.Invoke();
            };
        }

        public void Show()
        {
            var set = AScriptableObject.Get<Ad233Setting>();
            MetaAd.ShowBanner(set.bannerId, BannerAdCallback);
        }
    }
}
