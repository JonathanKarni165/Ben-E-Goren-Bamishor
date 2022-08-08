using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolSide : MonoBehaviour
{
    public bool spearMode;
    public GameObject r;
    public GameObject l;
    public static bool right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            if (spearMode)
            {
                if (doubleKnife.isKnife)
                {
                    r.SetActive(true);
                    l.SetActive(false);
                    right = true;
                }
            }
            else
            {
                r.SetActive(true);
                l.SetActive(false);
                right = true;
            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (spearMode)
            {
                if (doubleKnife.isKnife)
                {
                    r.SetActive(false);
                    l.SetActive(true);
                    right = false;
                }
            }
            else
            {
                r.SetActive(false);
                l.SetActive(true);
                right = false;
            }
        }
        
    }
}
