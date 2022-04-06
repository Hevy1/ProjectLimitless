using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float Y_MAX_ANGLE = 50f;
    private const float Y_MIN_ANGLE = 0f;

    public CharacterController controller;
    public Transform camTransform;
    public Transform lookAt;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float distance = 3f;
    Vector3 velocity;
    Vector2 currentRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 movement = input * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && controller.isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;

        controller.Move(movement);
        controller.Move(velocity * Time.deltaTime);

        Vector3 dir = new Vector3(0,0, - distance);
        currentRot += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentRot.y = Mathf.Clamp(currentRot.y, Y_MIN_ANGLE, Y_MAX_ANGLE);
        Quaternion rotation = Quaternion.Euler(currentRot.y, currentRot.x, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
