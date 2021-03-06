﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelTime = 120;

    private Slider slider;
    private AudioSource audioSource;
    private bool endOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("You Win");
        winLabel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = Time.timeSinceLevelLoad / levelTime;

        if(Time.timeSinceLevelLoad >= levelTime && !endOfLevel)
        {
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            endOfLevel = true;
        }
	}

    void LoadNextLevel ()
    {
        levelManager.LoadNextLevel();
    }
}
