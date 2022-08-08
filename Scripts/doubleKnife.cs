using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleKnife : MonoBehaviour
{
    public bool trapezeMode;
    public static bool invesibility;
    public static bool allowed;
    public GameObject knife;
    public GameObject knife2;
    public float delay;
    public float coolDown;
    float temp;
    float temp2;
    public static bool isKnife;
    bool canStab = true;
    bool enterence = true;
    void Start()
    {
        allowed = true;
        isKnife = false;
        invesibility = false;
    }

    // Update is called once per frame
    void Update()
    {

        invesibility = isKnife ? true : false;
        if (Input.GetKeyDown(KeyCode.DownArrow) && allowed && enterence)
        {
            StartCoroutine(TimeSystem());
            enterence = false;
        }
        if(trapezeMode)
        {
            if(!isKnife)
            {
                knife.SetActive(false);
                knife2.SetActive(false);
            }
        }

    }
    IEnumerator TimeSystem()
    {
        if (trapezeMode)
            GameObject.FindObjectOfType<AudioManager>().Play("knife");
        knife.SetActive(true);
        if(!trapezeMode)
            knife2.SetActive(true);
        isKnife = true;
        yield return new WaitForSeconds(delay);
        knife.SetActive(false);
        knife2.SetActive(false);
        isKnife = false;
        yield return new WaitForSeconds(coolDown);
        enterence = true;

    }
}
