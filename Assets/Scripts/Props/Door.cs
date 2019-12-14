using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
