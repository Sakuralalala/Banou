using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressDeltaOutput : StressEffect
{
    public float threadhold;
    public FloatEvent output;

    public override void OnStressChange(float deltaStress)
    {
        if (deltaStress > threadhold) output?.Invoke(deltaStress);
    }

}
