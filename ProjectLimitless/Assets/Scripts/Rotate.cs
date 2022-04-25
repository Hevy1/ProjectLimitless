using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(0f,.1f,0f);
    }
}
