using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleVector2Event : MonoBehaviour
{
    public Vec2Event output;
    public Vector2 input;
    public bool invokeOnStart;
    public bool invokeOnEnable;

    private void Start()
    {
        if (invokeOnStart) Invoke();
    }

    private void OnEnable()
    {
        if (invokeOnEnable) Invoke();
    }

    [ContextMenu("Invoke")]
    public void Invoke()
    {
        output?.Invoke(input);
    }

    public void Invoke(Vector2 input)
    {
        output?.Invoke(input);
    }

    public void SetX(float value)
    {
        input.x = value;
    }
    public void SetY(float value)
    {
        input.y = value;
    }

}
