using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaTest : MonoBehaviour
{
    Sprite square;
    
    void FixedUpdate()
    {
        square = gameObject.GetComponent<SpriteRenderer>().sprite;
        GameObject gm = new GameObject();
        
        gm.AddComponent<SpriteRenderer>();
        gm.AddComponent<SelfDestruct>();
        gm.GetComponent<SelfDestruct>().timer = 3;
        gm.GetComponent<SpriteRenderer>().sprite = square;
        Instantiate(gm, transform.position, transform.rotation);
    }
}
