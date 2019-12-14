using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

public class DialogSystemAgent : MonoBehaviour
{
    public string text;
    public Color color = Color.white;
    public void SetText(string text)
    {
        this.text = text;
    }

    public void TextPopUpToWorldSpace(Vector3 worldPostion)
    {
        DialogSystem.OutputToWorldSpace(worldPostion, text, color);

    }
    public void TextPopUpToScreenSpace(Vector2 screenPostion)
    {
        DialogSystem.OutputToScreenSpace(screenPostion, text, color);

    }
}
