using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    private Quaternion newRotation;
    public Transform player;
    public float smooth = 2f;
    public float yOffset, zOffset;

    private Vector3 newPos;
    

    void Start()
    {
        newPos = new Vector3(0, -0.04f, 0);       
    }

	void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(player.transform.forward, player.transform.up), Time.deltaTime * smooth);
    }
}
