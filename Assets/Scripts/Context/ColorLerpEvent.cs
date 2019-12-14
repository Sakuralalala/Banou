using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerpEvent : MonoBehaviour
{
    public Color min;
    public Color max;

    public ColorEvent output;
    public void Invoke(float t)
    {
        output?.Invoke(Color.Lerp(min, max, t));
    }
}
