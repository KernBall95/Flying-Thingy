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

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	

	void FixedUpdate () {
        if (Input.GetButton("Right") )
        {
            rb.AddForce(transform.right * movementStrength * 2);
        }
        if (Input.GetButton("Left"))
        {
            rb.AddForce(-transform.right * movementStrength * 2);
        }

            //transform.Rotate(transform.right * movementStrength * Time.deltaTime * 2);

            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
        /*if (Input.GetButton("Backward"))
        {
            transform.Rotate(-transform.right * movementStrength * Time.deltaTime * 2);
        }*/
        if (Input.GetButton("Jump"))
        {
            rb.velocity += transform.forward * movementStrength * Time.deltaTime;

            
        }
       /* else
        {
            rb.velocity -= transform.forward * Time.deltaTime * 10;
            if(currentSpeed < 5)
            {
                rb.velocity = transform.forward * currentSpeed;
            }
        }*/
        currentSpeed = rb.velocity.magnitude;

        Debug.DrawRay(transform.position, transform.forward, Color.red);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        /*if (currentSpeed < 10)
        {
            rb.velocity = transform.forward * 10;
        }*/
    }
}
