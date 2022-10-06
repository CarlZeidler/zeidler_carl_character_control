using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public float bulletVelocity = 20f;

    void Update()
    {
        FireGun();
    }

    void FireGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var newShot = GameObject.Instantiate(bullet, transform.position, transform.rotation);

            newShot.GetComponent<Rigidbody2D>().velocity = transform.up * bulletVelocity;
        }
    }
}
