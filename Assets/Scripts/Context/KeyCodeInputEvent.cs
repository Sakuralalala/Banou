using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Context/KeyCodeInputEvent")]
public class KeyCodeInputEvent : MonoBehaviour
{
    public UnityEvent output;
    public UnityEvent upOutput;
    public KeyCode input;

    private void Update()
    {
        if (Input.GetKeyDown(input)) output?.Invoke();
        if (Input.GetKeyUp(input)) upOutput?.Invoke();
    }

}
