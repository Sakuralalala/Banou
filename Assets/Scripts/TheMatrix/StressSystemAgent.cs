using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

public class StressSystemAgent : MonoBehaviour
{
    public void StressChange(float deltaStress)
    {
        StressSystem.stress += deltaStress;
        StressSystem.onStressChange?.Invoke(deltaStress);
    }
}
