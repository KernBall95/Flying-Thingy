using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided!");
        Destroy(this.gameObject);
        
    }
}
