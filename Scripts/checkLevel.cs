using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkLevel : MonoBehaviour
{ 
    public int levelIndex;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data.level >= levelIndex)
        {
            gameObject.SetActive(true);
        }
        else
            gameObject.SetActive(false);
    }
}
