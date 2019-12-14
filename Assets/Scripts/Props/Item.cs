using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 道具父类，靠近可交互
/// </summary>
public class Item : MonoBehaviour
{
    public UnityEvent output;
    public UnityEvent onEnter;
    public UnityEvent onExit;
    public bool forbidRepeatingInteraction = false; //防止重复交互

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onEnter?.Invoke();
            StartCoroutine(CheckInput());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onExit?.Invoke();
            StopAllCoroutines();
        }
    }
    private IEnumerator CheckInput()
    {
        while (true)
        {
            yield return 0;
            if (Input.GetKeyDown(GameSystem.LittleGirlSystem.Setting.interactKey))
            {
                output?.Invoke();
                if (forbidRepeatingInteraction) yield break;
            }
        }
    }
}
