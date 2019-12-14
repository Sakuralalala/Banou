using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressController : MonoBehaviour
{
    public bool realtimeControl = false;
    [Range(0, 1)]
    public float relativeStress = 0;
    public float delta;

    private void Update()
    {
        if (realtimeControl) GameSystem.StressSystem.Stress = GameSystem.StressSystem.Setting.maxStress * relativeStress;
    }

    public void AddStress(float delta)
    {
        GameSystem.StressSystem.Stress += delta;
        relativeStress = GameSystem.StressSystem.Stress / GameSystem.StressSystem.Setting.maxStress;
    }
    [ContextMenu("AddStress")]
    public void AddStress()
    {
        AddStress(delta);
    }

}
