using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    namespace PresentSetting
    {
        [CreateAssetMenu(fileName = "EffectSystemSetting", menuName = "系统配置文件/Effect System Setting")]
        public class EffectSystemSetting : ScriptableObject
        {
            [Header("Camera相关")]
            [Range(0, 1)]
            public float movingRate = 0.9f;     //相机移动的效率（0~1，越低越平滑，越高越快）
            public float reactDistance = 0.1f;  //相机震动效果的反应距离
        }
    }
}