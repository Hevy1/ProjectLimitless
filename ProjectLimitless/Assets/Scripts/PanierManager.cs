using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanierManager : MonoBehaviour
{
    private int count = 0;
    public DoorManager dr;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balle")
        {
            count++;
            Debug.Log("Balle ajoutée");
            Debug.Log(count);
            if (count == 4)
            {
                Debug.Log("Unlock the door");
                dr.Unlock(0);
            }
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
