using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class easterEggFound : MonoBehaviour
{
    public GameObject PlayerScript;
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            PlayerScript.GetComponent<Player>().FoundEgg();
            PlayerScript.GetComponent<Player>().SavePlayer();
            SceneManager.LoadScene(17);
        }
    }
}
