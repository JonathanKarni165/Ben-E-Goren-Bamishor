using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carRotation : MonoBehaviour
{
    Vector2 jump = new Vector2(0, 1000);
    float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        time = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.F) )&& time <= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            time = 5f;
        }
        else
            time -= Time.deltaTime;
    }
}
