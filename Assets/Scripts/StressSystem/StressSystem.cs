using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;
using System;

namespace GameSystem
{
    public class StressSystem : SubSystem<StressSystemSetting>
    {
        public static float stress { get; set; }

      
        public static Action<float> onStressChange;

    }
}
