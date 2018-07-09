using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementStrength;
    public float maxSpeed;
    public float currentSpeed = 0;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float audioPitchChangeRate;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private Rigidbody rb;
    private AudioSource audio;
    private float currentAudioPitch;
    private float minAudioPitch;
    private float maxAudioPitch;
    private Vector3 forward;
    

	void Start () {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        minAudioPitch = 0.2f;
        maxAudioPitch = 0.9f;
        
	}
	

	void FixedUpdate () {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        forward = transform.forward;
        

        if (Input.GetButton("Jump"))
        {
            rb.velocity += forward * movementStrength * Time.deltaTime;

            audio.pitch += Time.deltaTime * audioPitchChangeRate * 3;
            if (audio.pitch > maxAudioPitch)
            {
                audio.pitch = maxAudioPitch;
            }
        }
        else
        {
            audio.pitch -= Time.deltaTime * audioPitchChangeRate;
            
            if(audio.pitch < minAudioPitch)
            {
                audio.pitch = minAudioPitch;
            }
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
