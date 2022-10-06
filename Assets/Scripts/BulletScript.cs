using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float timer = 5f;

    void Update()
    {
        AutoDestroy();
    }

    void AutoDestroy()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target_NFT")
        {
            GlobalValues.currentScore += 10;
            Destroy(collision.gameObject);
        }
        
        Destroy(gameObject);
    }
}
