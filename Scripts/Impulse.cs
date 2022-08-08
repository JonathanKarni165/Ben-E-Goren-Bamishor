using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public float forceAmount; 
    void OnTriggerEnter2D(Collider2D c)
    {
        c.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceAmount,0));
        Destroy(gameObject);
    }
}
