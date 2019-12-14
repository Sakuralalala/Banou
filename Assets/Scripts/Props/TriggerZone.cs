using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 触发区域
/// </summary>
public class TriggerZone : MonoBehaviour
{
    public bool triggerOnlyOnce = false; //只触发一次
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private string GetID()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + transform.GetSiblingIndex();
    }
    private static List<string> triggerdZones = new List<string>();
    [RuntimeInitializeOnLoadMethod]
    private static void RegisterInit()
    {
        GameSystem.TheMatrix.onGameInitialize += Init;
    }
    private static void Init()
    {
        triggerdZones.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enabled) return;
        if (collision.CompareTag("Player"))
        {
            if (triggerOnlyOnce )
            {
                if (!triggerdZones.Contains(GetID()))
                {
                    onEnter?.Invoke();
                    triggerdZones.Add(GetID());
                }
            }
            else
            {
                onEnter?.Invoke();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onExit?.Invoke();
        }
    }
}
