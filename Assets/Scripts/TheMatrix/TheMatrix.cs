﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

namespace GameSystem
{
    /// <summary>
    /// 母体，游戏流程控制与消息处理
    /// </summary>
    [DisallowMultipleComponent]
    public class TheMatrix : MonoBehaviour
    {
        /// <summary>
        /// 游戏初始化委托，在游戏开始时和游戏重新开始时调用
        /// </summary>
        public System.Action onGameInitialize;

        //流程--------------------------------
        private IEnumerator _Start()
        {
            StartCoroutine(_StartScene());
            yield return 0;
        }

        //第一个场景
        public string _startScene;
        private IEnumerator _StartScene()
        {
            SceneManager.LoadScene(_startScene);

            onGameInitialize?.Invoke();

            //显示Logo
            ResetGameMessage();
            while (true)
            {
                yield return 0;
                if (GetGameMessage(GameMessage.Next)) break;
            }

            //进入下一个场景
        }

        ////场景名字记为_name
        //public string _logo;
        ///// <summary>
        ///// 开始的Logo场景
        ///// </summary>
        //private IEnumerator _Logo()
        //{
        //    SceneSystem.PushScene(_logo);
        //    //在进入每个状态前重置控制信息
        //    ResetGameMessage();
        //    while (true)
        //    {
        //        //提前return，延迟一帧开始检测
        //        yield return 0;
        //        if (GetGameMessage(GameMessage.Skip))
        //        {
        //            //不直接用嵌套，防止嵌套层数过深（是否有自动优化？没查到）
        //            StartCoroutine(_StartMenu());
        //            //结束
        //            yield break;
        //        }
        //    }
        //}

        //public string _startMenu;
        //private IEnumerator _StartMenu()
        //{
        //    yield return new WaitForSeconds(SceneSystem.PopAndPushScene(_startMenu));
        //    ResetGameMessage();
        //    while (true)
        //    {
        //        yield return 0;
        //        if (GetGameMessage(GameMessage.Start))
        //        {
        //            StartCoroutine(_Lobby());
        //            yield break;
        //        }
        //        if (GetGameMessage(GameMessage.Exit))
        //        {
        //            Application.Quit();
        //            yield break;
        //        }
        //    }
        //}

        //public string _lobby;
        //private IEnumerator _Lobby()
        //{
        //    yield return new WaitForSeconds(SceneSystem.PopAndPushScene(_lobby));
        //    ResetGameMessage();
        //    while (true)
        //    {
        //        yield return 0;
        //        if (GetGameMessage(GameMessage.Start))
        //        {
        //            StartCoroutine(_InGame());
        //            yield break;
        //        }
        //        if (GetGameMessage(GameMessage.Return))
        //        {
        //            StartCoroutine(_StartMenu());
        //            yield break;
        //        }
        //    }

        //}

        //public string _inGame;
        //private IEnumerator _InGame()
        //{
        //    yield return new WaitForSeconds(SceneSystem.PopAndPushScene(_inGame));
        //    ResetGameMessage();
        //    while (true)
        //    {
        //        yield return 0;
        //        if (GetGameMessage(GameMessage.Return))
        //        {
        //            StartCoroutine(_StartMenu());
        //            yield break;
        //        }
        //        if (GetGameMessage(GameMessage.Exit))
        //        {
        //            Application.Quit();
        //            yield break;
        //        }
        //    }
        //}













#if UNITY_EDITOR
        public bool test;
        public bool saveData;
#endif
        private static TheMatrix instance;
        private static TheMatrix Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.LogError("没有加载TheMatrix！");
                }
                return instance;
            }
        }

        //游戏控制----------------------------
        /// <summary>
        /// 记录游戏控制信息
        /// </summary>
        private static bool[] gameMessageReciver = new bool[System.Enum.GetValues(typeof(GameMessage)).Length];
        /// <summary>
        /// 检查游戏控制信息，收到则返回true
        /// </summary>
        /// <param name="message">要检查的信息</param>
        /// <param name="reset">是否在接收后重置</param>
        /// <returns>检查按钮信息，收到则返回true</returns>
        public static bool GetGameMessage(GameMessage message, bool reset = true)
        {
            if (gameMessageReciver[(int)message])
            {
                if (reset)
                    gameMessageReciver[(int)message] = false;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 发送 游戏控制信息
        /// </summary>
        /// <param name="message">信息</param>
        public static void SendGameMessage(GameMessage message)
        {
            gameMessageReciver[(int)message] = true;
        }
        /// <summary>
        /// 重置
        /// </summary>
        public static void ResetGameMessage()
        {
            gameMessageReciver.Initialize();
        }


        //协程控制----------------------------
        private static Dictionary<System.Type, LinkedList<Coroutine>> routineDictionaty = new Dictionary<System.Type, LinkedList<Coroutine>>();

        public static LinkedListNode<Coroutine> StartCoroutine(IEnumerator routine, System.Type key)
        {
            LinkedList<Coroutine> linkedList;
            if (routineDictionaty.ContainsKey(key))
            {
                linkedList = routineDictionaty[key];
            }
            else
            {
                linkedList = new LinkedList<Coroutine>();
                routineDictionaty.Add(key, linkedList);
            }
            LinkedListNode<Coroutine> node = new LinkedListNode<Coroutine>(null);
            node.Value = Instance.StartCoroutine(SubCoroutine(routine, node));
            linkedList.AddLast(node);

            return node;
        }
        public static void StopAllCoroutines(System.Type key)
        {
            if (!routineDictionaty.ContainsKey(key)) return;
            LinkedList<Coroutine> linkedList = routineDictionaty[key];

            foreach (Coroutine c in linkedList)
            {
                Instance.StopCoroutine(c);
            }

            linkedList.Clear();
        }
        public static void StopCoroutine(LinkedListNode<Coroutine> node)
        {
            if (node == null || node.List == null) return;
            Instance.StopCoroutine(node.Value);
            node.List.Remove(node);
        }
        private static IEnumerator SubCoroutine(IEnumerator inCoroutine, LinkedListNode<Coroutine> node)
        {
            yield return inCoroutine;
            node.List.Remove(node);
        }


        //存档控制----------------------------
        [SerializeField]
        private SavableObject[] dataToSave;

        private static void SaveTemporary(SavableObject data)
        {
            string stream = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(data.ToString(), stream);
            Debug.Log(data.name + " \tsaved!");
        }
        public static void Save(SavableObject data)
        {
            SaveTemporary(data);
            PlayerPrefs.Save();
            Debug.Log("Data saved to disc.");
        }
        public static void Load(SavableObject data)
        {
            if (!PlayerPrefs.HasKey(data.ToString()))
            {
                Debug.Log("No data found for " + data.name);
                return;
            }
            string stream = PlayerPrefs.GetString(data.ToString());
            JsonUtility.FromJsonOverwrite(stream, data);
            Debug.Log(data.name + " \tloaded!");
        }

        [ContextMenu("Save All Data")]
        public void SaveAll()
        {
            if (dataToSave == null || dataToSave.Length == 0) return;
            foreach (SavableObject so in dataToSave)
            {
                so.ReadData();
                SaveTemporary(so);
            }
            PlayerPrefs.Save();
            Debug.Log("Data saved to disc.");
        }
        public void LoadAll()
        {
            foreach (SavableObject so in dataToSave)
            {
                Load(so);
                so.OnLoad();
            }
        }
        [ContextMenu("Delete All Data")]
        public void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("All saved data deleted!");
        }


        //游戏启动----------------------------
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
            if (test)
#endif
                StartCoroutine(_Start());

#if UNITY_EDITOR
            else
                SceneManager.UnloadSceneAsync("System");
            if (saveData)
#endif
                LoadAll();
#if UNITY_EDITOR
            else
            {
                foreach (SavableObject so in dataToSave)
                {
                    so.OnLoad();
                }
            }
#endif

            //OnSubSystemInit?.Invoke();
        }
        private void OnDestroy()
        {
#if UNITY_EDITOR
            if (saveData)
#endif
            {
                SaveAll();
            }
        }
    }

    /// <summary>
    /// 控制信息枚举
    /// </summary>
    public enum GameMessage
    {
        LogoFinished,   //开始的Logo放出来了
        Next,
        Return,
        Exit
    }
}

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }
[System.Serializable]
public class Vec2Event : UnityEvent<Vector2> { }
[System.Serializable]
public class IntEvent : UnityEvent<int> { }
[System.Serializable]
public class Vec3Event : UnityEvent<Vector3> { }
[System.Serializable]
public class StringEvent : UnityEvent<string> { }


