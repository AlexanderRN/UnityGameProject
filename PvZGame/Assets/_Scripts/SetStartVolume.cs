﻿using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            float volume = PlayersPrefManager.GetMasterVolume();
            musicManager.SetVolume(volume);
        } else
        {
            Debug.LogWarning("No musicManager found.");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
