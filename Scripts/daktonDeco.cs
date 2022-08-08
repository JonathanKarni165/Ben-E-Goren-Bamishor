using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daktonDeco : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float angularSpeed;
    float angle =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, Time.deltaTime * speed));
        angle += Time.deltaTime * angularSpeed;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
