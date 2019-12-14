using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;

namespace GameSystem
{
    public class LittleGirlSystem : SubSystem<LittleGirlSystemSetting>
    {
        /// <summary>
        /// 当前控制器指针
        /// </summary>
        public static LittleGirlController theGirl = null;


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
