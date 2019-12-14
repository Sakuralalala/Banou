using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;
using System;

namespace GameSystem
{
    public class DollSystem : SubSystem<DollSystemSetting>
    {
        public static int dollHealth = 3;

        [RuntimeInitializeOnLoadMethod]
        private static void RegisterInit()
        {
            GameSystem.TheMatrix.onGameInitialize += Init;
        }
        private static void Init()
        {
            dollHealth = Setting.dollMaxHealth;
        }
    }
}

