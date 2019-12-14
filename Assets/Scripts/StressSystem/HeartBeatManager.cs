using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatManager : StressEffect
{
    public FloatEvent stressOutput;

    private int stressLevel = 1;
    public AudioClip[] heartBeatClips;
    public AudioSource heartBeatSource;

    public override void OnStressChange(float deltaStress)
    {
        float s = GameSystem.StressSystem.Stress / GameSystem.StressSystem.Setting.maxStress;
        stressOutput?.Invoke(s);

        int l = s > GameSystem.StressSystem.Setting.heartLevel3 ? 3 : s > GameSystem.StressSystem.Setting.heartLevel2 ? 2 : 1;

        if (l != stressLevel)
        {
            stressLevel = l;
            heartBeatSource.clip = heartBeatClips[l - 1];
            heartBeatSource.Play();
        }
    }
}
