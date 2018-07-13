using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    //Speed at which pitch changes
    public float audioPitchChangeRate;

    AudioSource audioSource;

    //Minimum and maximum pitch
    private float minAudioPitch;
    private float maxAudioPitch;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Setting the minimum and maximum pitch values
        minAudioPitch = 0.2f;
        maxAudioPitch = 0.9f;
    }

    public void IncreasePitch()
    {
        //Increase pitch
        audioSource.pitch += Time.deltaTime * audioPitchChangeRate * 3;

        //Clamp pitch to maximum value
        if (audioSource.pitch > maxAudioPitch)
        {
            audioSource.pitch = maxAudioPitch;
        }
    }

    public void DecreasePitch()
    {
        //Decrease pitch
        audioSource.pitch -= Time.deltaTime * audioPitchChangeRate;

        //Clamp pitch to minimum value
        if (audioSource.pitch < minAudioPitch)
        {
            audioSource.pitch = minAudioPitch;
        }
    }
}
