using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isMoving;

    private Rigidbody pRb;
    private float speed;
    private Transform parentTransform;
    private Vector3 position;
    private Vector3 lastPosition;
    public float audioPitch = 1;
    private float minPitch = 0.5f;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.pitch = this.audioPitch;
        parentTransform = this.transform.parent.gameObject.transform;
        position = parentTransform.position;
        lastPosition = position;

    }

    // Update is called once per frame
    void Update()
    {
        position = parentTransform.position;
        speed = ((position - lastPosition).magnitude)*3.6f;
        lastPosition = position;
        audioPitch = speed/100;
        if (audioPitch <= minPitch)
        {
            audioPitch = minPitch;
        }

        if (speed == 0)
        {
            audioPitch = 0;
        }
        audioSource.pitch = this.audioPitch;
    }
}
