using UnityEngine;
using System.Collections;

public class ActionMusicController : MonoBehaviour {
	
	private AudioSource audioSource;
	private AudioClip action;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("AudioManager") != null) {
			audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
			action = Resources.Load("Music/echo_action_track") as AudioClip;
			audioSource.Stop();
			audioSource.clip = action;
			audioSource.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
