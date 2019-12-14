using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloatEvent : MonoBehaviour
{
    public FloatEvent output;

    public Vector2 range;

    [ContextMenu("Invoke")]
    public void Invoke()
    {
        output?.Invoke(Random.Range(range.x, range.y));
    }
}
