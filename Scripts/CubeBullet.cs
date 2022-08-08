using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBullet : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce (CubeMovement.horizon ? new Vector2(0, Random.Range(-1, 1) * 300) : new Vector2(Random.Range(-1, 1) * 300, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
