using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    public GameObject key;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject spark;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "key")
        {
            Destroy(c.gameObject);
            key.SetActive(true);
            gameObject.layer = 0;
            stabbing.allowed = false;
        }
    }
    
}
