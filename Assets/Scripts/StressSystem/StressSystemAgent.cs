using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

public class StressSystemAgent : MonoBehaviour
{
    public void StressChange(float deltaStress)
    {
        StressSystem.Stress += deltaStress;
        StressSystem.onStressChange?.Invoke(deltaStress);
    }
}
