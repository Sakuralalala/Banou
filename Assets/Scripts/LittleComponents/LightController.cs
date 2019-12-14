using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightController : MonoBehaviour
{
    public bool isOn = true;
    public UnityEvent dimOut;
    public UnityEvent lightOn;

    [ContextMenu("DimOut")]
    public void DimOut()
    {
        if (isOn)
        {
            dimOut?.Invoke();
            isOn = false;
        }
    }
    [ContextMenu("LightOn")]
    public void LightOn()
    {
        if (!isOn)
        {
            lightOn?.Invoke();
            isOn = true;
        }
    }
}
