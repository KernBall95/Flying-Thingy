using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Movement settings
    public float movementStrength;
    public float maxSpeed;
    public float currentSpeed = 0;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float rollSpeed = 2.0f;

    //Rotation values
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float roll = 0.0f;

    //The players rigidbody
    private Rigidbody rb;

    //The player's forward direction
    private Vector3 forward;

    //Audio component which is accessed to change pitch
    PlayerAudio playerAudio;
    
	void Start () {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<PlayerAudio>();
	}
	
	void FixedUpdate () {
        yaw = speedH * Input.GetAxis("Mouse X");
        pitch = speedV * -Input.GetAxis("Mouse Y");
        roll = transform.eulerAngles.z;

        if (Input.GetButton("Left"))
        {
            roll += rollSpeed * Time.deltaTime;
        }
        if (Input.GetButton("Right"))
        {
            roll -= rollSpeed * Time.deltaTime;
        }
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, roll);
        transform.Rotate(pitch, yaw, 0f);
        
        forward = transform.forward;

        if (Input.GetButton("Jump"))
        {
            rb.velocity += forward * movementStrength * Time.deltaTime;
            playerAudio.IncreasePitch();           
        }
        else
        {
            playerAudio.DecreasePitch();
        }
        rb.velocity = forward.normalized * rb.velocity.magnitude;
        
        currentSpeed = rb.velocity.magnitude;

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
