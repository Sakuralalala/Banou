using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLittleGirlPostion : MonoBehaviour
{
    public string beforeSceneName;
    
    public void SetBeforeSceneName()
    {
        beforeSceneName = SceneManager.GetActiveScene().name;
        Debug.Log(beforeSceneName);
    }

    public void SetPostion()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        foreach(GameObject door in doors)
        {
            Debug.Log(beforeSceneName);
            Debug.Log(door.GetComponent<Door>().sceneName);
            if(door.GetComponent<Door>().sceneName == beforeSceneName)
            {
                Vector3 currentPos = door.transform.TransformPoint(door.transform.localPosition);
                Debug.Log(currentPos);
                GameSystem.LittleGirlSystem.theGirl.transform.position = currentPos;
            }
        }
    }
}
