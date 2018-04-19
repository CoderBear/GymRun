using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	MersenneTwister random;
	public int trackNumber = 0;
	public Text timerText;

	public GameObject soundManager;

	#region Fields
	int restSeconds;
	int roundedRestSeconds;

	public int totalTime;
	public int countDownSeconds;

	public bool timerActive;
	public bool gameOver;
	public bool timedOut;
	#endregion


	void Awake() {
		timerActive = true;
		gameOver = false;
		timedOut = false;

		countDownSeconds = 60;

		totalTime = 0;

		if (SoundManager.instance == null)
			Instantiate (soundManager);
	}
	// Use this for initialization
	void Start () {
		random = new MersenneTwister ();
		trackNumber = random.Next (1, 3);
		SoundManager.instance.musicSource[trackNumber].Play ();

		if (timerActive)
			InvokeRepeating ("Countdown", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("gameOver is " + gameOver.ToString ());
		if (GoalReached.instance.isGoalReached)
			gameOver = true;

		if (countDownSeconds == 0 && !gameOver) {
			timerActive = false;
			gameOver = true;
		}

		if (gameOver) {
			timerActive = false;
			SoundManager.instance.musicSource [trackNumber].Stop ();
			SceneManager.LoadScene (2);  // loads the the Game Over Screen which is the 3rd scene in the Unity build Settings;
		}
	}

	void Countdown(){
		if (countDownSeconds != 0) {
			totalTime++;
			countDownSeconds--;
			restSeconds = countDownSeconds;
			
			//display the timer
			roundedRestSeconds = Mathf.CeilToInt (restSeconds);
			roundedRestSeconds = Mathf.Clamp (roundedRestSeconds, 0, roundedRestSeconds);
			timerText.text = roundedRestSeconds.ToString ();
		}
	}
}