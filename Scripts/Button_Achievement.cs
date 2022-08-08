using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Achievement : MonoBehaviour
{
    public void ToRoom()
    {
        SceneManager.LoadScene(16);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
