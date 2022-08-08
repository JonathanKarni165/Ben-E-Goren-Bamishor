using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCircleMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    
    void Update()
    {
        gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
