using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    namespace PresentSetting
    {
        [CreateAssetMenu(fileName = "DialogSystemSetting", menuName = "系统配置文件/Dialog System Setting")]
        public class DialogSystemSetting : ScriptableObject
        {
            public GameObject textPrefab;
        }
    }
}

