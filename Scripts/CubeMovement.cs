using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Text txt;
    public Animator animator;
    public GameObject portal;
    public GameObject cone;
    public float jumpSpeed;
    Rigidbody2D rb;
    int directionX;
    int directionY;
    public int health;
    public float speed;
    private float gravitySpeed;
    public GameObject prefab;
    int shield;
    public int shieldT;
    int random;
    public static bool start;
    bool allowed;
    bool enterence;
    bool walled;
    bool fire;
    float timer;
    public float timer2Temp;
    float timer2;
    public static bool horizon;
    bool enterence2 = true;
    bool stop;
    bool phase2;
    public static bool phase3;
    public static bool dead;
    bool grounded;
    bool waitCone;
    bool finaleEnterence;
    bool invincablity;
    // Start is called before the first frame update
    void Start()
    {
        horizon = false;
        directionX = -1;
        shield = shieldT;
        rb = gameObject.GetComponent<Rigidbody2D>();
        start = true;
        allowed = true;
        timer = 2;
        timer2 = timer2Temp;
        enterence2 = true;
        gravitySpeed = 0;
        directionY = 1;
        walled = false;
        stop = false;
        phase2 = false;
        fire = true;
        phase3 = false;
        dead = false;
        waitCone = false;
        finaleEnterence = true;
        invincablity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            shield--;
        // test
        txt.text = shield + "";
        //velocity
        if (!stop && !start)
        {
            if(phase3)
                rb.velocity = new Vector2(directionX * speed, rb.velocity.y);
            else
                rb.velocity = new Vector2(horizon ? gravitySpeed * directionY : directionX * speed, horizon ? 1.2f * directionX * speed : rb.velocity.y);
        }
        //phases    
        if (!phase3)
        {
            if (Random.Range(0, 60) == 9 && timer <= 0 && !start && !horizon && !stop)
            {
                directionX *= -1;
                random = Random.Range(0, 2);
                if (!horizon)
                    StartCoroutine(ChangeGravityVertical());
                timer = 2f;
            }
            if (Random.Range(0, 60) == 9 && timer <= 0 && !start && horizon && !stop && !phase3)
            {
                directionY *= -1;
                gravitySpeed = 0;
                walled = false;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, directionY * 90);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + directionY, gameObject.transform.position.y);
                timer = 2f;
            }
            else
                timer -= Time.deltaTime;
            //weapon
            if (gameObject.transform.position.y > 3 && timer2 <= 0 && !horizon && fire)
            {
                Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
                timer2 = timer2Temp;
            }
            if (horizon && !walled && timer2 <= 0 && fire)
            {
                Instantiate(prefab, gameObject.transform.position, prefab.transform.rotation);
                timer2 = timer2Temp;
            }
            else
                timer2 -= Time.deltaTime;
        }
        //lost phase
        if(shield <= 0 && !phase2 && !phase3)
        {
            rb.gravityScale = 0;
            shield = shieldT;
            StartCoroutine(CutScene1());
            phase2 = true;
        }
        else if(shield <= 0 && phase2)
        {
            shield = 4;
            phase2 = false;
            phase3 = true;
            stop = true;
            horizon = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            StartCoroutine(CutScene2());
        }
        if (walled)
        {
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (!start && !dead)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //finale check
        if (phase3 && shield <= 0 && finaleEnterence)
        {
            dead = true;
            stop = true;
            StartCoroutine(CutScene3());
            finaleEnterence = false;
        }

    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(Random.Range(0.5f,1f));
        rb.AddForce(new Vector2(0, grounded? jumpSpeed : 0));
        if (!dead)
            StartCoroutine(Jump());
    }
    IEnumerator ChangeGravityVertical()
    {
        yield return new WaitForSeconds(0.3f);
        rb.gravityScale *= -1;
        if(rb.gravityScale!=0)
            gameObject.transform.localScale = new Vector2(1, rb.gravityScale);
        allowed = false;
    }
    IEnumerator HorizontalGravity()
    {
        yield return new WaitForSeconds(0.1f);
        if(!walled)
            gravitySpeed += 0.981f;
        StartCoroutine(HorizontalGravity());
    }
    IEnumerator TakingDamage()
    {
        animator.SetBool("damage", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("damage", false);
    }
    IEnumerator GainHealthAnim()
    {
        animator.SetBool("curing", true);
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("curing", false);
    }

    IEnumerator CutScene1()
    {
        invincablity = true;
        transform.rotation = Quaternion.Euler(0,0,0);
        gameObject.transform.localScale = new Vector2(1, 1);
        stop = true;
        transform.position = new Vector2(3.41f, 0.5f);
        rb.velocity = new Vector2(0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        animator.SetBool("woo", true);

        for (int i = 1; i<= 3; i++)
            Instantiate(portal, transform.position, transform.rotation);

        yield return new WaitForSeconds(3f);
        animator.SetBool("woo", false);
        horizon = true;
        timer = 2f;
        stop = false;
        transform.rotation = Quaternion.Euler(0, 0, directionY * 90);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        StartCoroutine(HorizontalGravity());
        invincablity = false;
    }
    IEnumerator CutScene2()
    {
        invincablity = true;
        //stoping motion
        rb.gravityScale = 0;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.localScale = new Vector2(1, 1);
        stop = true;
        transform.position = new Vector2(3.41f, 0.5f);
        rb.velocity = new Vector2(0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        animator.SetBool("anger", true);
        print(2);
        //releasing missile
        float angle = 90;
        for (int i =1; i<=3; i++)
        {
            Instantiate(cone, transform.position, Quaternion.Euler(0, 0, angle));
            angle += 120;
        }
        yield return new WaitForSeconds(2);
        //continue phase3
        
        animator.SetBool("anger", false);
        rb.gravityScale = 1;
        stop = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        speed *= 0.9f;
        StartCoroutine(Jump());
        StartCoroutine(curingAction());

        yield return new WaitForSeconds(2);
        waitCone = true;
        invincablity = false;
    }
    IEnumerator CutScene3()
    {
        //stoping motion
        rb.gravityScale = 0;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.localScale = new Vector2(1, 1);
        stop = true;
        transform.position = new Vector2(3.41f, 0.5f);
        rb.velocity = new Vector2(0, 0);
        animator.SetBool("bang", true);
        animator.SetBool("anger", false);

        yield return new WaitForSeconds(1);
        rb.gravityScale = 1;

        yield return new WaitForSeconds(1);

        dialogs.signal1 = true;
    }
    IEnumerator curingAction()
    {
        if(shield < 3)
        {
            StartCoroutine(GainHealthAnim());
            yield return new WaitForSeconds(0.3f);
            shield++;
        }
        else
            yield return new WaitForSeconds(0.05f);
        if(!dead)
            StartCoroutine(curingAction());
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "direction2")
        {
            if (!horizon)
                directionX *= -1;
            else
                walled = true;
        }
        if((c.gameObject.tag == "Floor" || c.gameObject.tag == "direction3") && horizon)
            directionX *= -1;
        if (c.gameObject.tag == "Floor")
        {
            grounded = true;
        }
        if (c.gameObject.tag == "sweethomealabama")
            Destroy(gameObject);
       
    }
    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "direction2")
        { 
            walled = false;
        }
        if (c.gameObject.tag == "Floor")
        {
            grounded = false;
        }
    }
        void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "argument" || c.gameObject.tag == "explanation")
        {
            if (!dead && !invincablity)
            {
                if (shield > 1)
                    StartCoroutine(TakingDamage());
                shield--;
            }

            Destroy(c.gameObject);
        }
        if(c.gameObject.tag == "homingMissile" && waitCone)
        {
            shield--;
        }
    }
}
