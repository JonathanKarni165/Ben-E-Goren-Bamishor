using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment2 : MonoBehaviour
{
    float timer;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z <= 0.71)
            timer += Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, timer * speed);
    }
}
