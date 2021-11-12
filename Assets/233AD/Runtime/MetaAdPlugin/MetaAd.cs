using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meta.Ad
{

    public class MetaAd : MonoBehaviour
    {

        private static AndroidJavaClass metaAdClass = new AndroidJavaClass("com.meta.android.mpg.cm.MetaAdApi");

        private static AndroidJavaObject GetInstance()
        {
            return metaAdClass.CallStatic<AndroidJavaObject>("get");
        }

        /// <summary>
        /// SDK初始化
        /// </summary> 
        public static void InitSdk(AndroidJavaObject context, string apiKey, InitCallback listener)
        {
            GetInstance()?.Call("init", context, apiKey, listener);
        }
        /// <summary>
        /// 显示激励视频广告
        /// </summary> 
        public static void ShowVideoAd(int pos, VideoAdCallback callback)
        {
            GetInstance()?.Call("showVideoAd",pos, callback);
        }

        /// <summary>
        /// 显示插屏广告
        /// </summary> 
        public static void ShowInterstitialAd(int pos, IAdCallback callback)
        {
            GetInstance()?.Call("showInterstitialAd", pos, callback);
        }


        /// <summary>
        /// 显示Banner广告
        /// </summary> 
        public static void ShowBanner(int pos, IAdCallback callback)
        {
            GetInstance()?.Call("showBannerAd", pos, callback);
        }

        /// <summary>
        /// 是否支持版本
        /// </summary> 
        public static bool IsInSupportVersion(int type)
        {
            var g = GetInstance();
            if (g != null)
                return g.Call<bool>("isInSupportVersion", type);
            return false;
        }



    }
}

