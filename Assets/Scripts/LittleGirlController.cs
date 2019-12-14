using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class LittleGirlController : MonoBehaviour
{
    public GameSystem.PresentSetting.LittleGirlSystemSetting setting { get => GameSystem.LittleGirlSystem.Setting; }
    public FloatEvent onSpeedChage;
    public FloatEvent onMove;

    private Rigidbody2D rid2d;

    [HideInInspector]
    public float speed;

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
}
