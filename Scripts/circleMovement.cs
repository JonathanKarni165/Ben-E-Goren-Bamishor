using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleMovement : MonoBehaviour
{
    public WheelJoint2D wj;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        JointMotor2D move = new JointMotor2D { motorSpeed = -speed*Input.GetAxisRaw("Horizontal"), maxMotorTorque = 10000 };
        wj.motor = move;
    }
}
