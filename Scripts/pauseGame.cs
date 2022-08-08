using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour
{
    public static bool pause = false;
    public GameObject menu;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightAlt)|| Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
                unfreezeGame();
            else
                freezeGame();
        }
    }
    public void freezeGame ()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        pause = true;
    }
    public void unfreezeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }
    public void quit()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
        SceneManager.LoadScene(0);
    }
    
}
