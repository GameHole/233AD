using System.Collections.Generic;
using UnityEngine;
namespace Ad233
{
    public class Ad233Setting : AScriptableObject
    {
        public override string filePath => "233Ad/Setting";
        public string appkey;
        public int rewardId;
        public int interstitialId;
        public int bannerId;
    }
}
