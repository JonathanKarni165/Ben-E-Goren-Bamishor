using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class circleHero : MonoBehaviour
{
    public float jumpSpeed;
    Rigidbody2D rb;
    bool canJump;
    public float jumpDelay;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        timer = jumpDelay;
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, Input.GetButtonDown("Jump")&&canJump ? jumpSpeed : rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
            canJumpSwitch();
        if (timer <= 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
            timer -= Time.deltaTime;
        }
        
    }
    public void canJumpSwitch()
    {
        timer = jumpDelay;
        canJump = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mapEnd")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if(collision.gameObject.tag == "NextScene")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
