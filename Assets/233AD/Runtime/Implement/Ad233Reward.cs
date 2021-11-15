using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
using System;
using System.Threading.Tasks;
using Meta.Ad;

namespace Ad233
{
    public class Ad233Reward : IRewardAdAPI,IInitializable
    {
        VideoAdCallback videoAdCallback;
        bool isReward;
        Action<bool> __onclose;
        TaskCompletionSource<bool> tcs;
        public bool isNotUseAd { get; set; }

        public event Action<bool> onClose;

        public void AutoShow(Action<bool> onclose)
        {
            __onclose = onclose;
            ShowInternal();
        }

        public Task<bool> AutoShowAsync()
        {
            tcs = new TaskCompletionSource<bool>();
            ShowInternal();
            return tcs.Task;
        }

        public void Initialize()
        {
            videoAdCallback = new VideoAdCallback();
            videoAdCallback.OnAdClose += closeInternal;
            videoAdCallback.OnAdReward += () =>
            {
                isReward = true;
            };
        }
        void closeInternal()
        {
            __onclose?.Invoke(isReward);
            onClose?.Invoke(isReward);
            if (tcs != null)
            {
                if (!tcs.Task.IsCompleted)
                    tcs.SetResult(isReward);
            }
        }
        void ShowInternal()
        {
            if (isNotUseAd)
            {
                isReward = true;
                closeInternal();
            }
            else
            {
                isReward = false;
#if UNITY_ANDROID
                var set = AScriptableObject.Get<Ad233Setting>();
                MetaAd.ShowVideoAd(set.rewardId, videoAdCallback);
#endif
            }
        }
        public bool isReady()
        {
            return true;
        }
    }
}
