using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class LittleGirlController : MonoBehaviour
{
    //Reference
    public GameSystem.PresentSetting.LittleGirlSystemSetting setting { get => GameSystem.LittleGirlSystem.Setting; }
    private Rigidbody2D rid2d;
    public Vector3 referencePos { get => transform.position + centerOffset; }   //参考中心点

    //Events
    public FloatEvent onSpeedChage;
    public FloatEvent onMove;

    //Properties
    //[HideInInspector]
    public float speed;
    public Vector3 centerOffset = Vector3.up * 0.75f;

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        speed = h * setting.maxSpeed;
        rid2d.velocity = new Vector2(speed, 0);
        
    }


    private void Awake()
    {
        rid2d = GetComponent<Rigidbody2D>();
        GameSystem.LittleGirlSystem.theGirl = this;
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(referencePos, 0.25f);
    }
}
