using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimation : MonoBehaviour {

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    public void PlaySound(Object sound)
    {
        audioSource.clip = (AudioClip)sound;
        audioSource.Play();
    }
}
