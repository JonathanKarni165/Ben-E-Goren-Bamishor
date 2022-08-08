using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    

    

    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y,-10);
    }
}
