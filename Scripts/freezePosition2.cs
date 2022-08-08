using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezePosition2 : MonoBehaviour
{
    public static bool unfreeze;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        unfreeze = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (unfreeze)
            rb.constraints = RigidbodyConstraints2D.None;
    }
}
