using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameSystem
{
    namespace PresentSetting
    {
        //人物相关
        [CreateAssetMenu(fileName = "LittleGirlSystemSetting", menuName = "系统配置文件/Little Girl System Setting")]
        public class LittleGirlSystemSetting : ScriptableObject
        {
            [Header("人物相关系统配置")]
            public float maxSpeed = 1;

            public KeyCode menuKey = KeyCode.Space;
            public KeyCode tortureKey = KeyCode.E;
        }
    }
}