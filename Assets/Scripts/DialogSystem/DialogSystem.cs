using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.PresentSetting;
using UnityEngine.UI;

namespace GameSystem
{
    public class DialogSystem : SubSystem<DialogSystemSetting>
    {
        public static Camera camera;

        //输出到屏幕空间
        public static void OutputToScreenSpace(Vector2 screenPosition, string text)
        {
            camera = Camera.main;
            float t = Mathf.Tan(camera.fieldOfView / 2);
            float y = (screenPosition.y - 0.5f) * t * 2;
            float x = (screenPosition.x - 0.5f) * t * 2;
            GameObject textObject = GameObject.Instantiate(Setting.textPrefab);
            textObject.transform.position = new Vector2(x, y);
            textObject.transform.SetParent(camera.transform);
            textObject.GetComponent<TextMesh>().text = text;
            //Debug.Log(new Vector2(x, y));
        }

        //输出到世界空间
        public static void OutputToWorldSpace(Vector3 worldPosition, string text)
        {
            GameObject textObject = GameObject.Instantiate(Setting.textPrefab);
            textObject.transform.position = worldPosition;
            textObject.GetComponent<TextMesh>().text = text;
            //Debug.Log(worldPosition);
        }

    }
}

