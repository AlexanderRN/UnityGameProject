﻿using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
	    DontDestroyOnLoad (gameObject);
        Debug.Log("Don't destroy on load: " + name);
	}

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level){
        AudioClip thisLevelMusic = levelMusicChangeArray[level];

        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic) // If music has attached element
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

	public void SetVolume(float volume) {
		audioSource.volume = volume;
	}
}
