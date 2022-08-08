using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAction : MonoBehaviour
{
    public Rigidbody2D rb;
    int direction = 1;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * direction, 0);
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "directionChanger")
            direction *= -1;
    }
}
