using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Context/RandomVector3Event")]
public class RandomVector3Event : MonoBehaviour
{
    [Header("Bounds")]
    public Vector3 min;
    public Vector3 max;
    public bool relative = true;   //相对坐标
    public Vec3Event output;

    [ContextMenu("Invoke")]
    public void Invoke()
    {
        output?.Invoke((relative ? transform.position : Vector3.zero) + new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z)));
    }

    public void SetMin(Vector3 value)
    {
        min = value;
    }
    public void SetMax(Vector3 value)
    {
        max = value;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube((relative ? transform.position : Vector3.zero) + (min + max) / 2f, (max - min));
    }
}
