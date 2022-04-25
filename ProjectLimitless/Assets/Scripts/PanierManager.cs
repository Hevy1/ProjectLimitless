using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanierManager : MonoBehaviour
{
    private int count = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balle")
        {
            count++;
        }

        if (count == 4)
        {
            Debug.Log("Unlock the door");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Balle")
        {
            count--;
        }
    }
}
