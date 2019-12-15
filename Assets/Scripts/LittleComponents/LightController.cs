using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightController : MonoBehaviour
{
    public bool isOn = true;
    public UnityEvent dimOut;
    public UnityEvent lightOn;

    private Collider2D col;

    [ContextMenu("DimOut")]
    public void DimOut()
    {
        if (isOn)
        {
            dimOut?.Invoke();
            isOn = false;
            col = gameObject?.GetComponentInChildren<Collider2D>();
            if (col) col.enabled = false;
        }
    }
    [ContextMenu("LightOn")]
    public void LightOn()
    {
        if (!isOn)
        {
            lightOn?.Invoke();
            isOn = true;
            if (col) col.enabled = true;
        }
    }
}
