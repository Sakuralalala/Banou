using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightManager : StressEffect
{
    private LightController[] lightControllers;
    private int dimIndex = 0;
    private void Start()
    {
        lightControllers = FindObjectsOfType<LightController>() as LightController[];

        //TODO 打乱顺序
        LightController[] lightTemp;
        lightTemp = new LightController[lightControllers.Length];
        for(int i = 0; i < lightTemp.Length; i++)
        {
            lightTemp[i] = lightControllers[i];
        }
        System.Random rand = new System.Random(DateTime.Now.Millisecond);
        for(int i = 0; i < lightTemp.Length; i++)
        {
            int x, y;
            LightController light;
            x = rand.Next(0, lightTemp.Length);
            do
            {
                y = rand.Next(0, lightTemp.Length);
            } while (y == x);
            light = lightTemp[x];
            lightTemp[x] = lightTemp[y];
            lightTemp[y] = light;
        }
        lightControllers = lightTemp;
        //Over
        
        foreach (LightController lc in lightControllers)
        {
            lc.GetComponentInChildren<ParticleSystem>()?.collision.SetPlane(0, transform);
        }
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
