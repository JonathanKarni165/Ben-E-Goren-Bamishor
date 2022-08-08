using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parachuting : MonoBehaviour
{
    public float parachutingSpeed;
    public float parachutingTime;
    Rigidbody2D rb;
    public Sprite charachterSprite;
    public Animator idleAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindObjectOfType<AudioManager>().Play("wind");
    }

    // Update is called once per frame
    void Update()
    {
        if (parachutingTime >= 0)
        {
            idleAnimator.SetBool("openParachute", true);
            rb.velocity = new Vector2(rb.velocity.x, parachutingSpeed);
            parachutingTime -= Time.deltaTime;
        }
        else
        {
            rb.gravityScale = 1f;
            FindObjectOfType<AudioManager>().Stop("wind");
            idleAnimator.SetBool("closeParachute", true);
            idleAnimator.SetBool("openParachute", false);
        }
    }
}
