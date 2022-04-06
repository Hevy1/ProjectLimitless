using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLevel : MonoBehaviour
{
    public Light[] lights;
    private int nLight = 0;

    public void OnTriggerEnter() {
        Debug.Log("Changing Lights");
        int newNLight = (nLight + 1) % lights.Length;
        lights[nLight].enabled = false;
        lights[newNLight].enabled = true;
        nLight = newNLight;
    }

}
