using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    int direction = -1;
    public Rigidbody2D rb;
    public GameObject prefab;
    bool hit1;
    bool hit2;
    public bool enableThrow;
    public bool keyHolder;
    // Start is called before the first frame update
    void Start()
    {
        if (enableThrow)
            InvokeRepeating("Pitagoras", 1f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 atRest = new Vector2(0, 0);
        Vector2 move = new Vector2(direction * 2f, rb.velocity.y);
        rb.velocity = move;
        if (hit1 && hit2)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Death")
        {
            direction *= -1;
        }
        if(c.gameObject.tag == "knife" && !keyHolder)
        {
            Destroy(gameObject);
        }
        if (c.gameObject.tag == "argument")
        {
            hit1 = true;
        }
        if (c.gameObject.tag == "explanation")
        {
            hit2 = true;
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            direction *= -1;
            
        }
    }
    void Pitagoras()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
