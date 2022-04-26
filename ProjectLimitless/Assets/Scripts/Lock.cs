using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    private bool isLocked = false;
    private Rigidbody rb;

    public bool GetState()
    {
        return this.isLocked;
    }

    public void SetState(bool state)
    {
        this.isLocked = state;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.freezeRotation = isLocked;
    }
}
