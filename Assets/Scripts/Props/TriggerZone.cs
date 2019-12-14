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
    public string triggeredKeyword;
    public string requiredKeyword;
    public string disableKeyword;

    private string GetID()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + transform.GetSiblingIndex();
    }
    private static List<string> triggerdZones = new List<string>();
    private static List<string> triggerdKeywords = new List<string>();
    [RuntimeInitializeOnLoadMethod]
    private static void RegisterInit()
    {
        GameSystem.TheMatrix.onGameInitialize += Init;
    }
    private static void Init()
    {
        triggerdZones.Clear();
        triggerdKeywords.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enabled) return;
        if (collision.CompareTag("Player"))
        {
            if (triggerOnlyOnce)
            {
                if (!triggerdZones.Contains(GetID()))
                {
                    DoTrigger();
                    triggerdZones.Add(GetID());
                }
            }
            else
            {
                DoTrigger();
            }
        }
    }
    private void DoTrigger()
    {
        if ((string.IsNullOrEmpty(requiredKeyword) || triggerdKeywords.Contains(requiredKeyword))
            && (string.IsNullOrEmpty(disableKeyword) || !triggerdKeywords.Contains(requiredKeyword)))
        {
            onEnter?.Invoke();
            if (!string.IsNullOrEmpty(triggeredKeyword) && !triggerdKeywords.Contains(triggeredKeyword))
            {
                triggerdKeywords.Add(triggeredKeyword);
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
