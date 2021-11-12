using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meta.Ad
{
    public class IAdCallback : AndroidJavaProxy
    {
        public event Action OnAdShow = delegate { };
        public event Action<int, string> OnAdShowFailed = delegate { };
        public event Action OnAdClick = delegate { };
        public event Action OnAdClose = delegate { };

        public IAdCallback() : base("com.meta.android.mpg.cm.api.IAdCallback") { }

        void onAdShow()
        {
            Debug.Log("-onAdShow-");
            OnAdShow.Invoke();
        }

        void onAdShowFailed(int code, string msg)
        {
            Debug.Log("-onAdShowFailed-code=" + code);
            OnAdShowFailed.Invoke(code, msg);
        } 

        void onAdClick()
        {
            Debug.Log("-onAdClick-");
            OnAdClick.Invoke();
        }

        void onAdClose()
        {
            Debug.Log("-onAdClose-");
            OnAdClose.Invoke();
        }
    }

}
