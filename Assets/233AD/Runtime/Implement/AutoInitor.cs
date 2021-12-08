using Meta.Ad;
using System.Collections.Generic;
using UnityEngine;
namespace Ad233
{
    public interface IAutoInit : IInterface
    {
    }

    public class AutoInitor : IAutoInit, IInitializable
    {
        public void Initialize()
        {
            InitCallback callback = new InitCallback();
            callback.OnInitSuccess += () =>
            {
                Debug.Log("init success result= ok");
            };
            callback.OnInitFailed += (code, msg) =>
            {
                Debug.Log("init error result=" + code + ",msg=" + msg);
            };
            var setting = AScriptableObject.Get<Ad233Setting>();
#if UNITY_ANDROID
            var app = GetApplicationContext();
            if (app != null)
                MetaAd.InitSdk(app, setting.appkey, callback);
            else
                Debug.LogWarning("Can not get ApplicationContext");
#endif
        }
#if UNITY_ANDROID
        public static AndroidJavaObject GetCurrentActivity()
        {
#if UNITY_EDITOR
            return null;
#else
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
#endif
        }

        public static AndroidJavaObject GetApplicationContext()
        {
            var act = GetCurrentActivity();
            if (act != null)
                return act.Call<AndroidJavaObject>("getApplicationContext");
            return null;
        }
#endif
    }
}
