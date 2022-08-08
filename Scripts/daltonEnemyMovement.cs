using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daltonEnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float force;
    bool firstBullet;
    bool secondBullet;
    int[] arr = { -1, 1 };
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(UpAndDown());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (firstBullet && secondBullet)
        {
            Destroy(gameObject);
            if (daltonMovement.speedIncrease < 1.6f)
                daltonMovement.speedIncrease += 0.1f;
        }

    }
    IEnumerator UpAndDown()
    {
        rb.velocity = new Vector2(speed, arr[(int)Random.Range(0,2)]*force);
        yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector2(speed, arr[(int)Random.Range(0, 2)]*force);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(UpAndDown());
    }
    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "argument" && c.gameObject.transform.rotation == Quaternion.Euler(0,0,0))
        {
            firstBullet = true;
        }
        if (c.gameObject.tag == "explanation" && c.gameObject.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            secondBullet = true;
        }
    }
}