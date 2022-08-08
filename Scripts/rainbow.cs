using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainbow : MonoBehaviour
{
    public SpriteRenderer sp;
    Color NewColor;
    public float speed;
    float red = 0, green = 255, blue = 0;

    // Update is called once per frame
    void Update()
    {
        NewColor = new Color(red, green, blue);
        sp.color = NewColor;

        if (green >= 255 && red<=255 && blue <=0)
            red += Time.deltaTime*speed;
        
        if (red >= 255 && green >= 0 && blue <= 0)
            green -= Time.deltaTime*speed;
        
        if (red >= 255 && blue <= 255 && green <= 0)
            blue += Time.deltaTime*speed;
        
        if (blue >= 255 && red >= 0 && green <= 0)
            red -= Time.deltaTime*speed;
        
        if (blue >= 255 && green <= 225 && red <= 0)
            green += Time.deltaTime*speed;
        
        
    }
}
