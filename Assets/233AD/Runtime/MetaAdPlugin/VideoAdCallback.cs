using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meta.Ad
{ 
    public class VideoAdCallback : AndroidJavaProxy
    {
        public event Action OnAdShow = delegate { };
        public event Action<int, string> OnAdShowFailed = delegate { };
        public event Action OnAdClick = delegate { };
        public event Action OnAdClose = delegate { };
        public event Action OnAdComplete = delegate { };
        public event Action OnAdClickSkip = delegate { };
        public event Action OnAdReward = delegate { };

        public VideoAdCallback() : base("com.meta.android.mpg.cm.api.IAdCallback$IVideoIAdCallback") {}

        void onAdShow()
        {
            Debug.Log("-video-onAdShow-");
            OnAdShow.Invoke();
        }

        void onAdShowFailed(int code, string msg)
        {
            Debug.Log("-video-onAdShowFailed-code=" + code);
            OnAdShowFailed.Invoke(code, msg);
        }

        void onAdClick()
        {
            Debug.Log("-video-onAdClick-");
            OnAdClick.Invoke();
        }

        void onAdClose()
        {
            Debug.Log("-video-onAdClose-");
            OnAdClose.Invoke();
        }

        void onAdComplete()
        {
            Debug.Log("-video-onAdComplete-");
            OnAdComplete.Invoke();
        }

        void onAdClickSkip()
        {
            Debug.Log("-video-onAdClickSkip-");
            OnAdClickSkip.Invoke();
        }

        void onAdReward()
        {
            Debug.Log("-video-onAdReward-");
            OnAdReward.Invoke();
        }
    }
 
}
