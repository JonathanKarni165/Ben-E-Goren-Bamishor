using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPreFab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float enemySpawnTime;
    public bool timeSpawn;
    public Vector2 endPoint;
    bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        if(timeSpawn)
            InvokeRepeating("Spawner", 2f, enemySpawnTime);
        end = false;
    }
    void Update()
    {
        if (gameObject.transform.position.x > endPoint.x && !timeSpawn)
            end = true;
    }
    // Update is called once per frame

    void Spawner()
    {
        if (!end)
        {
            Instantiate(enemyPreFab, spawnPoint1.position, spawnPoint1.rotation);
            Instantiate(enemyPreFab, spawnPoint2.position, spawnPoint1.rotation);
        }
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "spawn")
            InvokeRepeating("Spawner", 0f, enemySpawnTime);
    }
}
