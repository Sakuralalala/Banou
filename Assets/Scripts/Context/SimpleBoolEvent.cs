using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBoolEvent : MonoBehaviour
{
    public BoolEvent output;

    private void Start()
    {
       
    }

    [ContextMenu("Invoke")]
    public void Invoke(bool value)
    {
        output?.Invoke(value);
    }

}
