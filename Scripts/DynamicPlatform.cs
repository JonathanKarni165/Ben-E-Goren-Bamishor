using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPlatform : MonoBehaviour
{
    public float hight;
    public Rigidbody2D rb;
    int direction = -1;
    float hightCode;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + hight);
        rb.velocity = new Vector2(0, -hight);
        hightCode = (gameObject.transform.position.y + hight);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y >= hightCode)
        {
            direction *= -1;
        }
        if (gameObject.transform.position.y <= -hightCode)
        {
            direction *= -1;
        }
        rb.velocity = new Vector2(0, (hight * direction)*speed);
    }
}
