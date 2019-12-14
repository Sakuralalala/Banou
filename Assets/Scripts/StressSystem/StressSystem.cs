using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;
using System;

namespace GameSystem
{
    public class StressSystem : SubSystem<StressSystemSetting>
    {
        private static float stress;
        public static float Stress
        {
            get => stress;
            set
            {
                float deltaStress = value - stress;
                stress = value;
                if (stress > Setting.maxStress)
                {
                    stress = Setting.maxStress;
                }
                if (stress < 0)
                {
                    stress = 0;
                }
                onStressChange?.Invoke(deltaStress);
            }
        }


        public static Action<float> onStressChange;


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
