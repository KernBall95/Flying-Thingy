using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementStrength;
    public float maxSpeed;
    public float currentSpeed = 0;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Rigidbody rb;
    private Vector3 forward;

    PlayerAudio playerAudio;
    
	void Start () {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<PlayerAudio>();
	}
	
	void FixedUpdate () {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
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

        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
