using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    namespace PresentSetting
    {
        [CreateAssetMenu(fileName = "DollSystemSetting", menuName = "系统配置文件/Doll System Setting")]
        public class DollSystemSetting : ScriptableObject
        {
            public int dollMaxHealth;
            public Sprite[] dollPics;
            public GameObject bloodPrefab;
        }
    }
}

