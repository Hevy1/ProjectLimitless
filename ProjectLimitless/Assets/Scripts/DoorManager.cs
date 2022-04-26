using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private List<Lock> doorList = new List<Lock>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform door in transform)
        {
            doorList.Add(door.Find("01_low").GetComponent<Lock>());
        }

        
    }

    public void Unlock(int index)
    {
        doorList[index].SetState(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
