using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panic : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite sp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(clip());
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator clip()
    {
        yield return new WaitForSeconds(0.6f);
        sr.sprite = sp;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(11);
    }
}
