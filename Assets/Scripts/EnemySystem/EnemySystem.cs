using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;
using UnityEngine.SceneManagement;
namespace GameSystem
{
    public class EnemySystem : SubSystem<EnemySystemSetting>
    {
        
        public static GameObject enemy;
        public static bool[] roomIsLight;
        //敌人所在的房间编号
        public static int roomIndex;

        public static int level;

        //敌人体型大小
        public static float scale { get; set; }
        //倒计时减少系数
        public static float stepTimeValue;
        //敌人在房间停留时间
        public static float timeRamined { get; set; }

       
        //判断是否与敌人在同一场景
        //生成怪物，怪物文本
        private static bool IsMeetEnemy()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            int index = int.Parse(currentSceneName.Substring(4, currentSceneName.Length));

            if(index == roomIndex)
            {
                //设置怪物生成位置
                int xPoint = Random.Range(Setting.xPointMin, Setting.xPointMax);
                GameObject enemyObject = GameObject.Instantiate(Setting.enemyPrefab);
                if(level <= Setting.maxLevel)
                {
                    DialogSystem.OutputToWorldSpace(new Vector3(Setting.xTextPoint, Setting.yTextPoint), Setting.texts[level]);
                }
                
                enemyObject.transform.position = new Vector3(xPoint, Setting.yPoint);
                return true;
            }
            else
            {
                return false;
            }
        }


        //每次进门前判断一下level是否改变
        //level小于maxLevel,则增加
        public static void LevelChange()
        {
            if (IsMeetEnemy())
            {
                Debug.Log("与敌人在同一个场景中");
                if(level < Setting.maxLevel)
                {
                    level++;
                    scale += scale * Setting.scaleValue;
                    //模型变大
                    enemy.transform.localScale = scale * new Vector3(1, 1, 1);
                    timeRamined -= timeRamined * Setting.stepTimeValue;
                    Debug.Log(level);
                }
            }
            
        }

        //判断当前场景是否熄灯
        public static bool IsCurrentSceneLight()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            int index = int.Parse(currentSceneName.Substring(4, currentSceneName.Length));
            return roomIsLight[index];
        }

        //敌人状态
        public static IEnumerator EnemyAction()
        {

            if (level < Setting.maxLevel)
            {
                //未被激怒状态
                roomIndex = Random.Range(0, Setting.maxRoom);
                string sceneNameCurrent = SceneManager.GetActiveScene().name;
                while (("Room_" + roomIndex.ToString()) == sceneNameCurrent)
                {
                    roomIndex = Random.Range(0, Setting.maxRoom);
                    yield return 0;
                }

            }
            else
            {
                //激怒状态
                string sceneNameCurrent = SceneManager.GetActiveScene().name;
                GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
                foreach (GameObject door in doors)
                {
                    if (door.GetComponent<Door>().sceneName == sceneNameCurrent)
                    {
                        yield return 0;
                    }
                }
                roomIndex = Random.Range(0, doors.Length);
                yield return 0;
            }
            


            //倒计时,重新选房间
            yield return new WaitForSeconds(timeRamined);

            //倒计时结束
            yield return 0;
        }





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

