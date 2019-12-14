using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Listener/DebugPrinter")]
public class DebugPrinter : MonoBehaviour
{
    public string text;
    public void Print()
    {
        print(text);
    }
    public void PrintFloat(float input)
    {
        print(input);
    }
    public void PrintVector2(Vector2 input)
    {
        print(input);
    }
    public void PrintVector3(Vector3 input)
    {
        print(input);
    }
    public void PrintString(string input)
    {
        print(input);
    }
}
