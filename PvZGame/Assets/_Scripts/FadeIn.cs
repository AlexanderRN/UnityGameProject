using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class FadeIn : MonoBehaviour {

	public float fadeInTime;

	//Fading Panel
	private Image fadePanel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			// Fade
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else {
			// Deactivate Panel
			gameObject.SetActive (false);
		}
	}
}
