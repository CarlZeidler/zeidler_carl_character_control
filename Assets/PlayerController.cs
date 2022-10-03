using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody2D rb2d;

    void Start()
    {
        Application.targetFrameRate = 120;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    void Update()
    {


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //We don't need to multiply with Time.deltaTime since it's already the right unit.
        Vector2 movement = new Vector2(x, y) * speed;

        rb2d.velocity = movement;

        if (speed <= 8)
        {
            InvokeRepeating("SpeedUp", 5f, 5f);
        }

        Vector2 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = mousePos;
    }

    private void SpeedUp()
    {
        speed = speed + 1;
    }
}