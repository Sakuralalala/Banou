using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;

namespace GameSystem
{
    public class StressSystem : SubSystem<StressSystemSetting>
    {
        public static float stress { get; set; }

        public static FloatDelegate onStressChange;


    }
}
