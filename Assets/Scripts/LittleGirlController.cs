using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class LittleGirlController : MonoBehaviour
{
    [System.Serializable]
    public class Setting
    {
        public float maxSpeed;
        
        
        
    }
    public Setting setting;
    public FloatEvent onSpeedChage;
    public FloatEvent onMove;

    private Rigidbody2D rigidbody2D;
    
    public  float speed;

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //if(h != 0)
        //{
        //    if (h > 0)
        //    {
        //        speed += setting.addSpeed;
        //        if (speed >= setting.maxSpeed)
        //            speed = setting.maxSpeed;
        //    }
        //    else if(h < 0)
        //    {
        //        speed -= setting.addSpeed;
        //        if (speed <= setting.minSpeed)
        //            speed = setting.minSpeed;
        //    } 
        //}
        //else
        //{
        //    if(speed > 0.001)
        //    {
        //        speed -= setting.subSpeed;
        //    }
        //    else if(speed < -0.001)
        //    {
        //        speed += setting.subSpeed;
        //    }
        //    else
        //    {
        //        speed = 0;
        //    }
        //    speed -= h*
        //}
        speed = h * setting.maxSpeed;
        rigidbody2D.velocity = new Vector2(speed, 0);
    }


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
}
