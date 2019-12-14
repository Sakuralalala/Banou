using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : StressEffect
{
    private LightController[] lightControllers;
    private int dimIndex = 0;
    private void Start()
    {
        lightControllers = FindObjectsOfType<LightController>() as LightController[];
        //TODO 打乱顺序
        OnStressChange(GameSystem.StressSystem.Stress);
    }

    public override void OnStressChange(float deltaStress)
    {
        float l = GameSystem.StressSystem.Stress / GameSystem.StressSystem.Setting.maxStress * (lightControllers.Length + 1);
        while (l > dimIndex + 1)
        {
            lightControllers[dimIndex].DimOut();
            dimIndex++;
        }
        while (l < dimIndex)
        {
            dimIndex--;
            lightControllers[dimIndex].LightOn();
        }
    }
}
