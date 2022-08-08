using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogs : MonoBehaviour
{
    public Animator animator;
    public GameObject portalgun, pistol;
    public GameObject hye;
    public GameObject[] lastWords = new GameObject[4];
    public Rigidbody2D rb;
    public static bool signal1 = false , signal2 = false , signal3 = false;
    public bool cube;
    // Start is called before the first frame update
    void Start()
    {
        signal1 = false;
        signal2 = false;
        signal3 = false;
        StartCoroutine(Hello());
    }

    // Update is called once per frame
    void Update()
    {
        if(signal1)
        {
            StartCoroutine(finaleCutScene());
            signal1 = false;
        }
        if (signal2)
        {
            StartCoroutine(GoodEnding());
            signal2 = false;
        }
        if (signal3)
        {
            StartCoroutine(BadEnding());
            signal2 = false;
        }
    }
    IEnumerator Hello()
    {

        if (gameObject.tag == "Player")
            yield return new WaitForSeconds(1f);
        else
            yield return new WaitForSeconds(1.5f);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if (gameObject.tag == "Player")
            EnableFighting(false, gameObject);

        hye.SetActive(true);

        yield return new WaitForSeconds(2f);

        hye.SetActive(false);

        yield return new WaitForSeconds(6.5f);

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        CubeMovement.start = false;
        if (gameObject.tag == "Player")
            EnableFighting(true, gameObject);
        
    }
    IEnumerator finaleCutScene()
    {
        animator.SetBool("bang", false);
        animator.SetBool("surrender", true);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(1f);
        lastWords[0].SetActive(true);

        yield return new WaitForSeconds(2f);
        lastWords[0].SetActive(false);
        lastWords[1].SetActive(true);

        yield return new WaitForSeconds(2f);
        lastWords[1].SetActive(false);
        lastWords[2].SetActive(true);

        yield return new WaitForSeconds(2f);
        lastWords[2].SetActive(false);
        decision.signal = true;


    }
    IEnumerator GoodEnding()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("surrender", false);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        lastWords[3].SetActive(true);
        yield return new WaitForSeconds(2f);
        lastWords[3].SetActive(false);
        portalgun.SetActive(true);
        if (cube)
        {
            rb.AddForce(new Vector3(100, 400, 0));
        }
    }
    IEnumerator BadEnding()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(1f);
    }
    public static void EnableFighting(bool input ,GameObject g)
    {
        g.GetComponent<PistolSide>().enabled = input;
        g.GetComponent<ShootingSide>().enabled = input;
    }
}
