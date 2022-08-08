using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RandomAdd : MonoBehaviour
{
    public TextMeshPro txt;
    public TextMeshPro nextTxt;
    public GameObject multiplier;
    public float time;
    public bool multiply;
    int x, y, answer, z, g, answer2;
    public GameObject inputField;
    public int[] rangeAdd;
    public int[] rangeMult;
    // Start is called before the first frame update
    void Start()
    {
        x = (int)Random.Range(rangeAdd[0], rangeAdd[1]);
        y = (int)Random.Range(rangeAdd[0], rangeAdd[1]);
        z = (int)Random.Range(rangeMult[0], rangeMult[1]);
        g = (int)Random.Range(rangeMult[0], rangeMult[1]);
        answer = x + y;
        answer2 = g * z;
        if(!multiply)
            StartCoroutine(CheckAnswer1());
        if(multiply)
            StartCoroutine(CheckAnswer2());
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "" + x + " + " + y;
        nextTxt.text = "" + g + " * " + z;
    }
    IEnumerator CheckAnswer1()
    {
        yield return new WaitForSeconds(time);
        if (answer != textKeeper.inputValue)
            SceneManager.LoadScene(11);
        else
        {
            Destroy(gameObject);
            multiplier.SetActive(true);
        }
    }
    IEnumerator CheckAnswer2()
    {
        yield return new WaitForSeconds(time);
        if (answer2 != textKeeper.inputValue)
            SceneManager.LoadScene(11);
        else
        {
            Destroy(gameObject);
            inputField.SetActive(false);
        }
    }
}
