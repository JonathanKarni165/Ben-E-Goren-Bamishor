using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCheckpoint : MonoBehaviour
{
    
    void Start()
    {
        Destroy(GameObject.Find("cockroach"));
    }

    
}
