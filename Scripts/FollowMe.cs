using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{
    public static Transform squarePosition;

    // Update is called once per frame
    void Update()
    {
        squarePosition = gameObject.transform;
        homingMissile.target = squarePosition;
    }
}
