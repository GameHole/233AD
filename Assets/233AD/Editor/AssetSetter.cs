using System.Collections.Generic;
using UnityEngine;
using MiniGameSDK;
namespace Ad233
{
    public class AssetSetter : IParamSettng
    {
        public void SetParam()
        {
            AssetHelper.CreateAsset<Ad233Setting>();
        }
    }
}
