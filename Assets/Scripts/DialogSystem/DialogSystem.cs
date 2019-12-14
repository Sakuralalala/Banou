using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;

namespace GameSystem
{
    public class DialogSystem : SubSystem<DialogSystemSetting>
    {
        public static GameObject textPrefab;
        public static Camera camera;

        //输出到屏幕空间
        public static void OutputToScreenSpace(Vector2 screenPosition)
        {
            camera = Camera.main;
            float t = Mathf.Tan(camera.fieldOfView / 2);
            float y = (screenPosition.y - 0.5f) * t * 2;
            float x = (screenPosition.x - 0.5f) * t * 2;
            textPrefab = GameObject.Instantiate(Setting.textPrefab);
            textPrefab.transform.position = new Vector2(x, y);
            textPrefab.transform.SetParent(camera.transform);
            Debug.Log(new Vector2(x,y));
        }

        //输出到世界空间
        public static void OutputToWorldSpace(Vector3 worldPosition)
        {
            textPrefab = GameObject.Instantiate(Setting.textPrefab);
            textPrefab.transform.position = worldPosition;
            Debug.Log(worldPosition);
        }
    }
}

