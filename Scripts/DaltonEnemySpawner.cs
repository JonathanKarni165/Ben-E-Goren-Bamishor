using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaltonEnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform point;
    public float delay;
    public Transform endPoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", 1f, delay);
    }

    void Spawner()
    {
        if(point.position.x < endPoint.position.x)
            Instantiate(enemy, point.position, enemy.transform.rotation);
    }
}
