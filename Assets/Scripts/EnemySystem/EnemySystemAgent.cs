using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;
using UnityEngine.SceneManagement;

public class EnemySystemAgent : MonoBehaviour
{
    public bool isOver = false;
    
    public void StartTestEnemySystem()
    {
        EnemySystem.timeRamined = EnemySystem.Setting.maxStepTime;
        EnemySystem.LevelChange();
        if (isOver)
            EnemySystem.StartEnemyActionCoroutine();
        else
            EnemySystem.StopEnemyActionCoroutine();
    }

}
