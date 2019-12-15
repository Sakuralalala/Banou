using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    namespace PresentSetting
    {
        [CreateAssetMenu(fileName = "EnemySystemSetting", menuName = "系统配置文件/Enemy System Setting")]
        public class EnemySystemSetting : ScriptableObject
        {
            //最大房间数
            public int maxRoom;
            //房间是否亮
            public bool[] roomIsLight;
            //最大敌人激怒等级
            public int maxLevel;
            //最大倒计时时间
            public float maxStepTime;
            //体型增大系数
            public float scaleValue;
            //倒计时减少系数
            public float stepTimeValue;
            //敌人预制体
            public GameObject enemyPrefab;
            //怪物随机生成x坐标范围
            public int xPointMin;
            public int xPointMax;
            //怪物随机生成y坐标范围
            public int yPoint;
            //怪物的文本弹出点y坐标
            public int yTextPoint;
            //怪物的文本弹出点x坐标
            public int xTextPoint;
            //文本列表
            public string[] texts;
            //见面增加的压力值
            public float[] stressValue;
            //通关所需
            public int happyEndingRoomCount;
        }
    }
}

