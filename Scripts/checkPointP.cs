using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointP : MonoBehaviour
{
    void Start()
    {
        if (checkPoint.allow)
            transform.position = checkPoint.pos;
    }
    void Update()
    {
        if (transform.position.x > checkPoint.pos.x)
            checkPoint.allow = true;
    }
}
