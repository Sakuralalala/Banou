using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorSetter : MonoBehaviour
{
    public Image target;

    public void Set(Color color)
    {
        target.color = color;
    }
}
