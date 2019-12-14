using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

[AddComponentMenu("Listener/StressEffect")]
public class StressEffect : MonoBehaviour
{
    private void Awake()
    {
        StressSystem.onStressChange += OnStressChange;
        
        
    }
    
    public void OnStressChange(float deltaStress)
    {
        Debug.Log(StressSystem.stress);
        
    }

    
}
