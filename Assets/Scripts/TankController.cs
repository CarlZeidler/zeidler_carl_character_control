using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float turningSpeed = 90f;
    public float speed = 1f;
    public float maxSpeed = 5f;
    public float reverseSpeed = 1f;
    public float maxReverseSpeed = 3f;
    public float acceleration = 0.5f;

    private float angle;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") >= 0)
        { 
            angle -= Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        }
        else
        {
            angle += Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        }
        
        rb2d.MoveRotation(angle);
        
        float y = Input.GetAxis("Vertical");

        if (y > 0)
        { 
            rb2d.velocity = rb2d.transform.up * y * speed;
            speed += 0.5f * Time.deltaTime;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }
        else if (y < 0)
        {
            rb2d.velocity = rb2d.transform.up * y * reverseSpeed;
            reverseSpeed += 0.5f * Time.deltaTime;
            if (reverseSpeed > maxReverseSpeed)
            {
                reverseSpeed =  maxReverseSpeed;
            }
        }
        else if (y == 0 && speed > 0 || reverseSpeed > 0)
        {
            speed -= rb2d.drag * Time.deltaTime * 2;
            reverseSpeed -= rb2d.drag * Time.deltaTime;
        }

        if (speed <= 1)
        {
            speed = 1;
        }

        if (reverseSpeed <= 1)
        {
            reverseSpeed = 1;
        }
    }
}
