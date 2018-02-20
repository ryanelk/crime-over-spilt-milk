using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour {

	public AudioClip a1;
	public AudioClip a2;
	public AudioClip a3;

	AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	void Update() {

		if (Input.GetKeyDown(KeyCode.Q)) {
			audioSource.clip = a1;
			audioSource.Play();

		}
		if (Input.GetKeyDown(KeyCode.W)) {
			audioSource.clip = a2;
			audioSource.Play();

		}
		if (Input.GetKeyDown(KeyCode.E)) {
			audioSource.clip = a3;
			audioSource.Play();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			gameObject.SetActive(false);
		}
	}


}
