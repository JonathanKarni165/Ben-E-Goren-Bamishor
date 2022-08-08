using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Sprite dead;
    public Sprite alive;
    public Vector2 portalExit;
    SpriteRenderer sp;

    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "portal")
        {
            if(sp.sprite == dead)
            {
                ParticleSystem.end = true;
                Destroy(gameObject);
            }
            if(sp.sprite == alive)
            {
                sp.sprite = dead;
                transform.position = portalExit;
            }
        }
    }
}