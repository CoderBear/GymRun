using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelected : MonoBehaviour {

	public GameObject playerMale;
	public GameObject playerFemale;

	// Use this for initialization
	void Start () {

		if (GoalReached.instance.isMale) {
			playerMale.SetActive (true);
			playerFemale.SetActive (false);
		} else {
			playerMale.SetActive (false);
			playerFemale.SetActive (true);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
