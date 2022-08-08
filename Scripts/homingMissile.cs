using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class homingMissile : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public static Transform target;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 point = (Vector2)target.position- rb.position;
        point.Normalize();
        float rotationAmount = Vector3.Cross(point, transform.up).z;

        rb.velocity = transform.up * speed;
        rb.angularVelocity = -rotationAmount * rotationSpeed;
    }
}
