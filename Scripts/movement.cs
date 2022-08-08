using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    float invicabilityDelay;
    public bool textEnable;
    public bool audio;
    public int currentSceneNumber;
    public float speed;
    public float jumpSpeed;
    Rigidbody2D rb;
    bool grounded;
    public float health;
    public GameObject PlayerScript;
    GameObject text;
    public static float delay;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(textEnable)
        {
            text = GameObject.FindGameObjectWithTag("healthText");
        }
        invicabilityDelay = 0.9f;
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButtonDown("Jump") && grounded;
        rb.velocity = new Vector2(axis * speed, jump ? jumpSpeed : rb.velocity.y);
        if(textEnable)
            text.GetComponent<Text>().text = " " + health;
        delay -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "trapeze" && doubleKnife.invesibility == false && !TrapezeMovement.dead)
        {
            StartCoroutine(Death());
        }
        if (collision.gameObject.tag == "trap")
            freezePosition2.unfreeze = true;
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "grivs")
        {
            StartCoroutine(Death());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "direction2")
        {
            grounded = false;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Death" || collision.gameObject.tag == "TrapezeW" || collision.gameObject.tag == "homingMissile") && delay <=0)
        {
            delay = invicabilityDelay;
            if (health <= 1)
            {
                
                StartCoroutine(Death());
            }
            else
            {
                health--;

            }
        }


        if (collision.gameObject.tag == "collectible1")
        {
            TrapezeMovement.score++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "portal2")
        {
            SceneManager.LoadScene(12);
            PlayerScript.GetComponent<Player>().CancellMaster();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "directionChanger" || collision.gameObject.tag == "button" || collision.gameObject.tag == "direction2" || collision.gameObject.tag == "direction3")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "trapeze" && !doubleKnife.invesibility && !TrapezeMovement.dead)
        {
            StartCoroutine(Death());
        }

    }
    IEnumerator Death()
    {
        print(true);
        PlayerScript.GetComponent<Player>().CancellMaster();
        if (audio)
        { 
            FindObjectOfType<AudioManager>().Play("death");
            yield return new WaitForSeconds(0.6f);
        }
        SceneManager.LoadScene(currentSceneNumber);
    }
}
