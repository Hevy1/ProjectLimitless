using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private int nbCP = 0;
    public DoorManager doorManager;
    public void Add()
    {
        nbCP++;
        if (nbCP == 7)
        {
            Debug.Log("Unlock the door");
            doorManager.Unlock(0);
            

        }
    }
    
}
