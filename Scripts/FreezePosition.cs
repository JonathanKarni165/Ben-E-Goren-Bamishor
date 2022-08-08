using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePosition : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "freeze")
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
