using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameSystem;

public class SetLittleGirlPostion : MonoBehaviour
{
    public static string beforeSceneName;
    
    public void SetBeforeSceneName()
    {
        beforeSceneName = SceneManager.GetActiveScene().name;
        
    }

    public void SetPostion()
    {
        
       
        
        //每进入新的场景时，判断一下是否和敌人在一个场景
        EnemySystem.LevelChange();
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        foreach(GameObject door in doors)
        {
            
            if (door.GetComponent<Door>().sceneName == beforeSceneName)
            {
                
                this.gameObject.transform.position = door.transform.GetChild(1).position;
                
                
            }
        }
    }

   

    private void Start()
    {
        SetPostion();
    }
}
