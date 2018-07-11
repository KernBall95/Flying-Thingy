using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    public float audioPitchChangeRate;

    AudioSource audioSource;

    private float currentAudioPitch;
    private float minAudioPitch;
    private float maxAudioPitch;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        minAudioPitch = 0.2f;
        maxAudioPitch = 0.9f;
    }

    public void IncreasePitch()
    {
        audioSource.pitch += Time.deltaTime * audioPitchChangeRate * 3;
        if (audioSource.pitch > maxAudioPitch)
        {
            audioSource.pitch = maxAudioPitch;
        }
    }

    public void DecreasePitch()
    {
        audioSource.pitch -= Time.deltaTime * audioPitchChangeRate;

        if (audioSource.pitch < minAudioPitch)
        {
            audioSource.pitch = minAudioPitch;
        }
    }
}
