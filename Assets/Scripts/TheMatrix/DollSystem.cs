using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;

namespace GameSystem
{
    public class DollSystem : SubSystem<DollSystemSetting>
    {
        public static float dollHealth { get; set; }

        public static FloatDelegate onDollHeathChange;
    }
}

