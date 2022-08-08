using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleSystem : MonoBehaviour
{
    public int nextSceneNumber;
    public static bool end = false;
    void Update()
    {
        if(end)
        {
            StartCoroutine(psSwitch());
            end = false;
        }
        
    }
    IEnumerator psSwitch()
    {
        gameObject.GetComponent<UnityEngine.ParticleSystem>().Play();
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<UnityEngine.ParticleSystem>().Stop();
        SceneManager.LoadScene(nextSceneNumber);
    }
}
