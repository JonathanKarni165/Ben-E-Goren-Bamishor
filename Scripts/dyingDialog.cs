using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class dyingDialog : MonoBehaviour
{
    public Animator anim;
    public GameObject[] lastWords;
    float phase;
    public int finaleSceneNumber;
    void Start()
    {
        phase = 0;
        StartCoroutine(show());
    }
    IEnumerator show()
    {
        while (phase == 0)
        {
            yield return null;
        }
        anim.SetBool("GotShot", true);
        lastWords[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        lastWords[0].SetActive(false);

        while (phase == 1)
        {
            yield return null;
        }
        anim.SetBool("Dimention", true);
        lastWords[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        lastWords[1].SetActive(false);

        while (phase == 2)
        {
            yield return null;
        }
        anim.SetBool("2D", true);
        lastWords[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        lastWords[2].SetActive(false);

        while (phase == 3)
        {
            yield return null;
        }
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        anim.SetBool("1D", true);
        lastWords[3].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        lastWords[3].SetActive(false);

        while (phase == 4)
        {
            yield return null;
        }
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        anim.SetBool("0D", true);
 
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(finaleSceneNumber);
    }
    void OnTriggerEnter2D (Collider2D c)
    {
        if (c.gameObject.tag == "dimention")
            phase++;
    }

    
}
