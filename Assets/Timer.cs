using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private Text displayedTime;

    private float time;
    void Start () {
        displayedTime = GetComponent<Text>();
	}
	
	void Update () {
        //Increase time by seconds
        time += Time.deltaTime;

        //Format the time into minutes and seconds
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        displayedTime.text = min.ToString("00") + ":" + sec.ToString("00");
    }
}
