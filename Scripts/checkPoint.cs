using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkPoint : MonoBehaviour
{
    public Vector2 position;
    public static Vector2 pos;
    private static checkPoint ck;
    public static bool allow = false;

    void Awake()
    {
        
        pos = position;
        if (ck == null)
        {
            ck = this;
            DontDestroyOnLoad(ck);
        }
        else
            Destroy(gameObject);
    }
}
