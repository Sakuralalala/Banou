using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

public class DollSystemAgent : MonoBehaviour
{
    public void DollHealthChange(float value)
    {
        DollSystem.dollHealth -= value;
        DollSystem.onDollHeathChange?.Invoke(value);
    }
}
