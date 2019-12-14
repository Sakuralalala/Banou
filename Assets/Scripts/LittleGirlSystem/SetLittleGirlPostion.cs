using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLittleGirlPostion : MonoBehaviour
{
    public static string beforeSceneName;
    
    public void SetBeforeSceneName()
    {
        beforeSceneName = SceneManager.GetActiveScene().name;
        
    }

    public void SetPostion()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        foreach(GameObject door in doors)
        {
            
            if (door.GetComponent<Door>().sceneName == beforeSceneName)
            {
                this.gameObject.transform.position = door.transform.position;
            }
        }
    }
    private void Start()
    {
        SetPostion();
    }
}
