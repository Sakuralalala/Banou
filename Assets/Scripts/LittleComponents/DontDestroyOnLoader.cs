using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小组件，让挂载的游戏物体独立于场景，应该只用于只加载一次的场景如System场景中
/// </summary>
public class DontDestroyOnLoader : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
