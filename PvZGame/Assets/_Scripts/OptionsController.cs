using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();

		volumeSlider.value = PlayersPrefManager.GetMasterVolume ();
		difficultSlider.value = PlayersPrefManager.GetDifficulty ();

	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume (volumeSlider.value);
	}

	public void SaveAndExit() {
		PlayersPrefManager.SetMasterVolume (volumeSlider.value);
		PlayersPrefManager.SetDifficulty (difficultSlider.value);
		levelManager.LoadLevel ("01a Start");
	}
}
