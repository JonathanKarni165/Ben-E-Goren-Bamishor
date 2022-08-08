using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    Vector2 highestPoint;
    bool enterence;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        enterence = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(LinearFunction.finish && !enterence)
        {
            highestPoint = LinearFunction.highestPoint;

            if (highestPoint.x > 0)
            {
                highestPoint = new Vector2(highestPoint.x - 5f, highestPoint.y + 5f);
            }
            if (highestPoint.x < 0)
            {
                highestPoint = new Vector2(highestPoint.x + 5f, highestPoint.y + 5f);
            }

            StartCoroutine(Spawner());
            enterence = true;
        }
        
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(prefab, highestPoint, gameObject.transform.rotation);
        StartCoroutine(Spawner());
    }
}
