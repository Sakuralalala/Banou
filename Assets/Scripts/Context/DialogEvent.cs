using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogEvent : MonoBehaviour
{
    [System.Serializable]
    public class DialogUnit
    {
        [Multiline(2)]
        public string text;
        public float delay;
    }
    public DialogUnit[] dialogUnits;

    public StringEvent output;
    public UnityEvent onStartOutput;
    public UnityEvent onEndOutput;
    public void Invoke()
    {
        StopAllCoroutines();
        StartCoroutine(outputInOrder());
    }
    private IEnumerator outputInOrder()
    {
        onStartOutput?.Invoke();
        foreach (DialogUnit du in dialogUnits)
        {
            output?.Invoke(du.text);
            yield return new WaitForSeconds(du.delay);
        }
        onEndOutput?.Invoke();
    }
}
