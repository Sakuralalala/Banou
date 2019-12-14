using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;
using System;

namespace GameSystem
{
    public class DollSystem : SubSystem<DollSystemSetting>
    {
        public static float dollHealth { get; set; }

        public static Action<float> onDollHeathChange;


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

