using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;
using UnityEngine.UI;

public class DollSystemAgent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent onTorture;

    private void Start()
    {
        GetComponent<Image>().overrideSprite = DollSystem.Setting.dollPics[DollSystem.dollHealth];
    }

    public void TortureDoll()
    {
        DollSystem.dollHealth--;
        if (DollSystem.dollHealth < 0)
        {
            TheMatrix.SendGameMessage(GameMessage.GameOver);
            DollSystem.dollHealth = 0;
        }
        else
        {
            GetComponent<Image>().overrideSprite = DollSystem.Setting.dollPics[DollSystem.dollHealth];
            onTorture?.Invoke();
        }
    }
}
