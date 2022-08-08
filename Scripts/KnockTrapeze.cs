using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockTrapeze : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trapeze")
        {
            print("ja");
            if (transform.position.x <
                GameObject.FindObjectOfType<TrapezeMovement>().transform.position.x)
                TrapezeMovement.direction1 *= -1;

            if (transform.position.x >
                GameObject.FindObjectOfType<TrapezeMovement>().transform.position.x)
                TrapezeMovement.direction1 *= -1;
        }
    }
}
