using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatThreadholdEvent : MonoBehaviour
{
    [SerializeField]
    private float value;
    public float target;
    public float threadhold;
    private bool underThreadhold = true;
    [Range(0, 1)]
    public float rate = 0.9f;

    public FloatEvent updateOutput;
    public UnityEvent onOverThreadhold;
    public UnityEvent onBelowThreadhold;

    public void SetTarget(float t)
    {
        target = t;
    }

    private void Update()
    {
        float t = 1.0f - Mathf.Pow(1.0f - rate, Time.deltaTime / Time.timeScale);
        value = Mathf.Lerp(value, target, t);
        updateOutput?.Invoke(value);
        if (underThreadhold)
        {
            if (value > threadhold)
            {
                underThreadhold = false;
                onOverThreadhold?.Invoke();
            }
        }
        else
        {
            if (value < threadhold)
            {
                underThreadhold = true;
                onBelowThreadhold?.Invoke();
            }
        }
    }
}
