using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearFunction : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject prefab;
    public GameObject player;
    Vector2 point2 = new Vector2(0,0);
    Vector2 point1 = new Vector2(0,0);
    public static Vector2 highestPoint = new Vector2(0, 0);
    public float speed;
    bool enterence1;
    bool enterence2;
    public static bool finish;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        enterence1 = true;
        enterence2 = true;
        finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enterence1 && Input.GetMouseButtonDown(0))
        {
            point1 = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 7);
            transform.position = point1;
            enterence1 = false;
        }
        if (enterence2 && Input.GetMouseButtonDown(1))
        {
            point2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            InvokeRepeating("Spawner", 0f, 0.0001f);
            enterence2 = false;
            finish = true;
        }
        if (finish)
        {
            transform.position = Vector3.MoveTowards(transform.position, point2, speed * Time.deltaTime);

            if (point1.y > point2.y)
                highestPoint = point1;
            else
                highestPoint = point2;

            player.SetActive(true);
        }
    }
    void Spawner()
    {
        if(transform.position.y != point2.y)
        Instantiate(prefab, transform.position, transform.rotation);
    }

}
