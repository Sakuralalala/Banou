using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;


namespace GameSystem
{
    /// <summary>
    /// 特效系统，用于管理特效
    /// </summary>
    public class EffectSystem : SubSystem<EffectSystemSetting>
    {

        [RuntimeInitializeOnLoadMethod]
        private static void RegisterInit()
        {
            GameSystem.TheMatrix.onGameInitialize += Init;
        }
        private static void Init()
        {
            //Init here
        }
    }
}
