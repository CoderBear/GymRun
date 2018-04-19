using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndScript : MonoBehaviour
{

	[SerializeField]
	private GameObject fitTipObject;

	public Text fitTip;

	public Button restartButton;
	public Button titleButton;

	[SerializeField]
	public List<string> tips;

	MersenneTwister random;

	void Awake ()
	{
		SoundManager.instance.musicSource [4].Play (); // plays end track
	}

	// Use this for initialization
	void Start ()
	{
		random = new MersenneTwister ();
//		int result;

//		if (tips.Count < 0) {
//			tips.Add ("Finish your weight training with a few high rep sets. This will push more blood into the muscle and blood carries nutrients so get it in there to help build and recover.");
//			tips.Add ("When doing barbell bench press squeeze your hands in on the bar to really activate chest");
//			tips.Add ("Hire a great personal trainer to push you and teach you to progression");
//			tips.Add ("If you struggle with front squats practise with 2 kettlebells holding them up with your elbows down by your side");
//			tips.Add ("Change your weights program every 4 weeks");
//			tips.Add ("Change your weights program every 4 weeks");
//			tips.Add ("Do NOT avoid carbs, just avoid the nasty ones.");
//			tips.Add ("Through some body weight routines into your program, this will do wonders");
//			tips.Add ("Listen to mum- eat your greens daily");
//			tips.Add ("You can’t target an area to burn fat, instead train larger muscles and more muscle groups at once");
//		}

		// show tip if goal was reached before time was up and show random health tip
		if (GoalReached.instance.isGoalReached) {
			fitTip.text = tips[random.Next(0, tips.Count)];
			fitTipObject.SetActive (true);
		} else if (!GoalReached.instance.isGoalReached) {
			fitTipObject.SetActive (false);
		}
	}

	// Allows player to play another round of the game with out starting from the Title Screen.
	public void RestartGame ()
	{
		GoalReached.instance.isGoalReached = false;
		SoundManager.instance.musicSource [4].Stop ();
		SceneManager.LoadScene (1);
	}

	// Returns game to the Title Screen/Main Menu
	public void ReturnToTitle ()
	{
		GoalReached.instance.isGoalReached = false;
		SoundManager.instance.musicSource [4].Stop ();
		SceneManager.LoadScene (0);
	}
}
