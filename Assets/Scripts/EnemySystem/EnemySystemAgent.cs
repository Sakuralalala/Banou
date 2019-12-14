using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;
using UnityEngine.SceneManagement;

public class EnemySystemAgent : MonoBehaviour
{

    //public IEnumerator EnemyAction()
    //{

    //    if (EnemySystem.level < EnemySystem.Setting.maxLevel)
    //    {
    //        //未被激怒状态
    //        EnemySystem.roomIndex = Random.Range(0, EnemySystem.Setting.maxRoom);
    //        string sceneNameCurrent = SceneManager.GetActiveScene().name;
    //        while (("Room_" + EnemySystem.roomIndex.ToString()) == sceneNameCurrent)
    //        {
    //            EnemySystem.roomIndex = Random.Range(0, EnemySystem.Setting.maxRoom);
    //            yield return 0;
    //        }

    //    }
    //    else
    //    {
    //        //激怒状态
    //        string sceneNameCurrent = SceneManager.GetActiveScene().name;
    //        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
    //        foreach (GameObject door in doors)
    //        {
    //            if (door.GetComponent<Door>().sceneName == sceneNameCurrent)
    //            {
    //                yield return 0;
    //            }
    //        }
    //        EnemySystem.roomIndex = Random.Range(0, doors.Length);
    //        yield return 0;
    //    }
    //    //倒计时,重新选房间
    //    yield return new WaitForSeconds(EnemySystem.timeRamined);
    //    //倒计时结束
    //    yield return 0;
    //}


}
