using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public bool enableFallAnim = false;
    bool grounded = false;
    bool suit;
    Rigidbody2D rb;
    public Animator animator;
    float time;
    bool FixedGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        FixedGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.gravityScale == 1f)
            if (Input.GetAxisRaw("Horizontal") != 0)
                if (grounded)
                {
                    animator.SetBool("walking", true);
                }
        if (rb.gravityScale == 1f)
            if (Input.GetAxisRaw("Horizontal") == 0)
                if (grounded)
                    animator.SetBool("walking", false);
        if (!grounded)
            animator.SetBool("walking", false);
        if (!FixedGrounded&& enableFallAnim)
        {
           
                animator.SetBool("falling", true);
                Debug.Log("falling");
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            grounded = true;
            animator.SetBool("falling", false);
            time = 1f;
        }
        if (collision.gameObject.tag == "Enemey")
            animator.SetBool("takingDamage", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            grounded = false;
        }
        if (collision.gameObject.tag == "Enemey")
            animator.SetBool("takingDamage", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death" && movement.delay <=0)
        {
            animator.SetTrigger("Shake");
        }
        if (collision.gameObject.tag == "Death"|| collision.gameObject.tag == "TrapezeW")
        {
            animator.SetBool("takingDamage", true);
        }
        if (collision.gameObject.tag == "Floor")
        {
            FixedGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death"|| collision.gameObject.tag == "TrapezeW")
        {
            animator.SetBool("takingDamage", false);
        }
        if (collision.gameObject.tag == "Floor")
        {
            FixedGrounded = false;
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "floor")
            FixedGrounded = true;
    }

}
