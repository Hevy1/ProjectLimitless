using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    private Light lt;

    private Color c; 

    private float colorSlider = 1f;
    void Start()
    {
        lt = GetComponent<Light>();
        c = lt.color;
    }

    // Update is called once per frame
    void Update()
    {
        int r = Random.Range(0, 2);
        if (r == 0) c.r += colorSlider * Time.deltaTime;
        else c.r -= colorSlider * Time.deltaTime;
        if (c.r <= 0) c.r = 0;
        
        r = Random.Range(0, 2);
        if (r == 0) c.g += colorSlider * Time.deltaTime;
        else c.g -= colorSlider * Time.deltaTime;
        if (c.g <= 0) c.g = 0;
        
        r = Random.Range(0, 2);
        if (r == 0) c.b += colorSlider * Time.deltaTime;
        else c.b -= colorSlider * Time.deltaTime;
        if (c.b <= 0) c.b = 0;

        lt.color = c;

    }
}
