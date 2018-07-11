using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public Transform player;
    public float smooth = 2f;
    public float yOffset, zOffset;

	void Update () {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(player.transform.forward, player.transform.up), Time.deltaTime * smooth);
        }
    }
}
