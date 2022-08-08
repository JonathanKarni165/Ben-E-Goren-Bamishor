using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageTrailColor : MonoBehaviour
{
    public Color color;
    void Update()
    {
        if (daltonMovement.speedIncrease >= 1.6)
        {
            gameObject.GetComponent<TrailRenderer>().startColor = color;
            gameObject.GetComponent<TrailRenderer>().endColor = color;
        } 
    }
}
