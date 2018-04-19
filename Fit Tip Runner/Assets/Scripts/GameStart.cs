using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	public GameObject soundManager;
	public GameObject goalManager;

	void Awake(){
		if (SoundManager.instance == null)
			Instantiate (soundManager);
		if (GoalReached.instance == null)
			Instantiate (goalManager);
	}

	// Use this for initialization
	void Start () {
//		SoundManager.instance.musicSource [0].Play (); // plays the title screen track
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		GoalReached.instance.isMale = true;
		SoundManager.instance.musicSource [0].Stop ();
		SceneManager.LoadScene (1);  // Load the game scene
	}

	public void StartGameFemale() {
		GoalReached.instance.isMale = false;
		SoundManager.instance.musicSource [0].Stop ();
		SceneManager.LoadScene (1);  // Load the game scene
	}
}
