using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatCollision : MonoBehaviour
{
    public GameObject zavit;
    public GameObject zela;
    public Transform t;
    bool hafifa;
    float delayC = 1f, delay = 1f;
    void Update()
    {
        delay -= Time.deltaTime;
    }
    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "knife" && delay<=0)
        {
            delay = delayC;
            TrapezeMovement.health--;
            t.position = new Vector2(1f,2.5f);
            StartCoroutine(At());
        }
    }
    IEnumerator At()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(hafifa ? zavit : zela, new Vector2(Random.Range(-8f, 10f), Random.Range(-2.7f, 4f)), zavit.transform.rotation);
        hafifa = !hafifa;
        if (TrapezeMovement.health < 1)
            Destroy(gameObject);
    }
}
