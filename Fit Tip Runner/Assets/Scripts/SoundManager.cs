using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource[] musicSource;
	public static SoundManager instance = null;

	void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}

	void Start() {
		for (int i = 0; i < musicSource.Length; i++) {
			musicSource [i].enabled = true;
		}
	}
}
