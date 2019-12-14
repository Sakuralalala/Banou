using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;
using UnityEngine.SceneManagement;

public class Door : Item
{
    
    public string sceneName;
    public StringEvent onEnterDoor;
    public Transform littleGirlPosition;

    private void Start()
    {
        littleGirlPosition = this.transform.GetChild(1);
    }

    public void OnEnterDoor()
    {
        onEnterDoor?.Invoke(sceneName);
    }

    public void DoorEffect()
    {
        //bool isNext;
        string sceneNameCurrent = SceneManager.GetActiveScene().name;
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        foreach(GameObject door in doors)
        {
            if(door.GetComponent<Door>().sceneName == "Room "+ EnemySystem.roomIndex)
            {
                //表示敌人在附近
                GetComponent<SimpleEvent>()?.Invoke();
                
            }
        }


    }

}
