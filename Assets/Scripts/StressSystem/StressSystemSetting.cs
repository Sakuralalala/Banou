using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameSystem
{
    namespace PresentSetting
    {
        [CreateAssetMenu(fileName = "StressSystemSetting", menuName = "系统配置文件/Stress System Setting")]
        public class StressSystemSetting : ScriptableObject
        {
            public float maxStress;

            public float heartLevel2 = 0.4f;
            public float heartLevel3 = 0.8f;

            public float darkStressRate = 0.5f;
        }
    }
}

