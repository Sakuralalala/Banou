using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressDeltaOutput : StressEffect
{
    public float threadhold;
    public FloatEvent output;
    public bool inverse = false;

    public override void OnStressChange(float deltaStress)
    {
        if (inverse == deltaStress < threadhold) output?.Invoke(deltaStress);
    }

}
