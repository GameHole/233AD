using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meta.Ad
{ 
    public class InitCallback : AndroidJavaProxy
    {
        public event Action OnInitSuccess = delegate { };
        public event Action<int, string> OnInitFailed = delegate { };

        public InitCallback() : base("com.meta.android.mpg.cm.api.InitCallback")
        {
        }

        /// <summary>
        /// SDK初始化成功回调
        /// </summary> 
        void onInitSuccess()
        {
            Debug.Log("SDK init success");
            OnInitSuccess.Invoke();
        }

        /// <summary>
        /// SDK初始化失败回调
        /// </summary> 
        void onInitFailed(int code, string msg)
        {
            Debug.Log("sdk init failed," + code + ",msg=" + msg);
            OnInitFailed.Invoke(code, msg);
        }
    }
}