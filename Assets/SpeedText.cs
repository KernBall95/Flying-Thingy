using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour {

    public PlayerMovement playerMovement;
    Text sText;

	void Start () {
        sText = GetComponent<Text>();
	}
	
	void Update () {
        sText.text = playerMovement.currentSpeed.ToString();
	}
}
