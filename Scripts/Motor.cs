using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Motor : MonoBehaviour
{
    public GameObject wheel1;
    public GameObject wheel2;
    public WheelJoint2D wheel;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject spark;
    private float speed = 750;
    private float reverseSpeed = 400;
    public float acceleration;
    public float speedLimit;
    private float temp = 750;
    bool enterence = false;
    bool engineOn;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        speed = 750f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump")&& engineOn)
        {
            if (enterence)
                speed = temp;
            if (speed < speedLimit)
            {
                speed *= acceleration;
            }
            enterence = false;

            start = true;
        }
        if (Input.GetKey(KeyCode.DownArrow) && engineOn)
        {
            speed = -reverseSpeed;
            start = true;
            enterence = true;
        }
        else
        {
            if (!Input.GetButton("Jump") && !Input.GetKey(KeyCode.DownArrow))
            {
                speed /= 1.01f;
                enterence = true;
            }
        }
        
    }
    void FixedUpdate ()
    {
        if (start)
        {
            JointMotor2D move = new JointMotor2D { motorSpeed = -speed, maxMotorTorque = 10000 };
            wheel.motor = move;
        }
        
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Destroy(c.gameObject);
            cam1.SetActive(false);
            cam2.SetActive(true);
            StartCoroutine(StartMotor());
        }
        
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "yachal1")
        {
            Destroy(c.gameObject);
            gameObject.layer = 10;
            wheel1.layer = 10;
            wheel2.layer = 10;
        }
    }
    IEnumerator StartMotor()
    {
        spark.SetActive(true);
        yield return new WaitForSeconds(1f);
        spark.SetActive(false);
        engineOn = true;
    }
}
