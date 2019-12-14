using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

[AddComponentMenu("Listener/DollEffect")]
public class DollEffect : MonoBehaviour
{
    private void Awake()
    {
        DollSystem.onDollHeathChange += OnDollHealthChange;


    }

    public void OnDollHealthChange(float value)
    {
        Debug.Log(DollSystem.dollHealth);

    }
}
