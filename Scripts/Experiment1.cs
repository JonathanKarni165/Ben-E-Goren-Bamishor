using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment1 : MonoBehaviour
{
    Rigidbody2D rb;
    float Force = 0;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Force = 0;
        StartCoroutine(K());
        StartCoroutine(K2());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Force, rb.velocity.y);
    }
    IEnumerator K()
    {
        Force = Force + 0.981f;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(K());
    }
    IEnumerator K2()
    {
        yield return new WaitForSeconds(1f);
        print(Force);
    }
}
