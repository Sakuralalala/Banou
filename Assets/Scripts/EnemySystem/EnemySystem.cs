using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;
using UnityEngine.SceneManagement;
namespace GameSystem
{
    public class EnemySystem : SubSystem<EnemySystemSetting>
    {

        public static GameObject enemyObject;
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
        //游戏是否通关
        public static bool isHappyEnding;

        //判断是否与敌人在同一场景
        //生成怪物，怪物文本
        private static bool IsMeetEnemy()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            int index = int.Parse(currentSceneName.Substring(5, currentSceneName.Length - 5));


            if (index == roomIndex)
            {
                //设置怪物生成位置
                int xPoint = Random.Range(Setting.xPointMin, Setting.xPointMax);
                enemyObject = GameObject.Instantiate(Setting.enemyPrefab);
                enemyObject.transform.position = new Vector3(xPoint, Setting.yPoint, 0);
                if (level < Setting.maxLevel)
                {
                    DialogSystem.OutputToWorldSpace(new Vector3(Setting.xTextPoint, Setting.yTextPoint) + enemyObject.transform.position, Setting.texts[level]);
                }

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
                if (StressSystem.Stress >= StressSystem.Setting.maxStress * 0.95f) TheMatrix.SendGameMessage(GameMessage.GameOver);
                if (level < Setting.maxLevel)
                {
                    level++;
                    scale += level * Setting.scaleValue;
                    //模型变大

                    timeRamined -= level * Setting.stepTimeValue;
                    Debug.Log(level);
                }
                Debug.Log(scale);
                enemyObject.transform.localScale = scale * new Vector3(1, 1, 1);
                //笑声
                enemyObject.GetComponent<SimpleEvent>()?.Invoke();
                //StressSystem.Stress += Setting.stressValue[Mathf.Min(3, level)];
            }

        }

        //判断当前场景是否熄灯
        public static bool IsCurrentSceneLight()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            int index = int.Parse(currentSceneName.Substring(5, currentSceneName.Length - 5));
            return roomIsLight[index];
        }

        public static void StartEnemyActionCoroutine()
        {
            StartCoroutine(EnemyAction());
        }

        public static void StopEnemyActionCoroutine()
        {
            //...
            StopAllCoroutines();
        }

        //敌人状态
        public static IEnumerator EnemyAction()
        {
            while (true)
            {
                Debug.Log("怪物开始找房间");
                if (level < Setting.maxLevel)
                {
                    //未被激怒状态
                    roomIndex = Random.Range(1, Setting.maxRoom);
                    string sceneNameCurrent = SceneManager.GetActiveScene().name;
                    while (("Room " + roomIndex.ToString()) == sceneNameCurrent)
                    {
                        roomIndex = Random.Range(1, Setting.maxRoom);
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
                    roomIndex = Random.Range(1, doors.Length);
                    yield return 0;
                }

                Debug.Log("怪物出现在Room " + roomIndex);
                Debug.Log("倒计时时间为" + timeRamined);
                //倒计时,重新选房间
                yield return new WaitForSeconds(timeRamined);

                //倒计时结束
                Debug.Log("倒计时结束");
            }

        }

        //public static void StartGameOverCheck()

        public static IEnumerator GameOverCheck()
        {
            while (true)
            {
                yield return 0;
                if (StressSystem.Stress >= 0.9 * StressSystem.Setting.maxStress && IsMeetEnemy())
                {
                    TheMatrix.SendGameMessage(GameMessage.GameOver);
                }
                if (SceneManager.GetActiveScene().name == "GameWin")
                {
                    TheMatrix.SendGameMessage(GameMessage.GameWin);
                }
            }
        }



        [RuntimeInitializeOnLoadMethod]
        private static void RegisterInit()
        {
            GameSystem.TheMatrix.onGameInitialize += Init;
        }
        private static void Init()
        {
            //Init here
            Debug.Log("Enemy System Inited");
            timeRamined = Setting.maxStepTime;
        }

    }
}

