using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;// 10
    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = new Vector2(speed, rb.velocity.y);
        StartCoroutine(BulletDecay());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    IEnumerator BulletDecay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D (Collider2D c)
    {
        if (c.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}
