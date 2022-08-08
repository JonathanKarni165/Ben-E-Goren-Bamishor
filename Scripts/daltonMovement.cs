using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class daltonMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float health;
    public static float speedIncrease = 1f;
    public Text txt;
    public Text txt2;
    public Animator anim;
    public GameObject PlayerScript;
    bool toEnfinityAndBeyond;
    public float endSceneDuration;
    bool entrence = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        speedIncrease = 1f;
        entrence = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speedIncrease*20, speedIncrease*Input.GetAxisRaw("Vertical")*speed);
        if(health <= 0)
        {
            PlayerScript.GetComponent<Player>().CancellMaster();
            SceneManager.LoadScene(9);
        }
        txt.text = "Health Points : " + health;
        txt2.text = "Speed : " + speedIncrease * 1000;

        if (toEnfinityAndBeyond)
            speedIncrease += 0.01f;
        if (transform.position.x >= 900 && entrence)
        {
            FindObjectOfType<AudioManager>().Play("lightspeed");
            entrence = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "argument" && c.gameObject.transform.rotation == Quaternion.Euler(0, 0, -180))
        {
            health--;
        }
        if (c.gameObject.tag == "explanation" && c.gameObject.transform.rotation == Quaternion.Euler(0, 0, -180))
        {
            health--;
        }
        if (c.gameObject.tag == "enemyJet")
        {
            SceneManager.LoadScene(9);
        }
        if (c.gameObject.tag == "yachal1")
        {
            
            anim.SetBool("LightSpeed", true);
            toEnfinityAndBeyond = true;
            Destroy(c.gameObject);
            StartCoroutine(Galaxy());
        }
    }
    IEnumerator Galaxy()
    {
        yield return new WaitForSeconds(endSceneDuration);
        SceneManager.LoadScene(10);
    }
}
