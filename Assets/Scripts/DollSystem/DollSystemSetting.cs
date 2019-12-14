using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    namespace PresentSetting
    {
        [CreateAssetMenu(fileName = "DollSystemSetting", menuName = "系统配置文件/Doll SystemS etting")]
        public class DollSystemSetting : ScriptableObject
        {
            public float dollHealth;
        }
    }
}

