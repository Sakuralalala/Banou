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
        }
    }
}

