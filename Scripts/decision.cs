using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class decision : MonoBehaviour
{
    public Animator caMera;
    public GameObject[] option = new GameObject[2];
    public GameObject select;
    bool right,enterence;
    public static bool signal;
    // Start is called before the first frame update
    void Start()
    {
        signal = false;
        enterence = true;
    }

    // Update is called once per frame
    //actually right is left...
    void Update()
    {

        if (signal)
        {
            if(enterence)
            {
                signalFunction();
                enterence = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                select.transform.position = option[1].transform.position;
                right = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                select.transform.position = option[0].transform.position;
                right = false;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (right)
                {
                    option[1].GetComponent<Animator>().SetBool("bold", true);
                    option[0].GetComponent<Animator>().SetBool("fadeAway", true);
                    well.signal3 = true;
                    dialogs.signal3 = true;
                    StartCoroutine(Endecision());
                    caMera.SetBool("dark", true);
                }
                else if (!right)
                {
                    option[1].GetComponent<Animator>().SetBool("fadeAway", true);
                    option[0].GetComponent<Animator>().SetBool("bold", true);
                    dialogs.signal2 = true;
                    StartCoroutine(Endecision());
                    StartCoroutine(toGoodWorld());

                }
                select.SetActive(false);
            }
        }
    }
    
    public void signalFunction()
    {
        dialogs.EnableFighting(false, gameObject);
        option[0].SetActive(true);
        option[1].SetActive(true);
        select.SetActive(true);
        transform.position = new Vector2(-3.27f, -3.27f);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }
    IEnumerator Endecision()
    {
        if (right)
            yield return new WaitForSeconds(3f);
        else
            yield return new WaitForSeconds(15f);
        option[1].SetActive(false);
        option[0].SetActive(false);
    }
    IEnumerator toGoodWorld()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(15);
    }
}
