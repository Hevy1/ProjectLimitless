using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour
{
    public CheckPointManager manager;
    private bool notActivated = true;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && notActivated)
        {
            manager.Add();
            notActivated = false;
        }
    }
}
