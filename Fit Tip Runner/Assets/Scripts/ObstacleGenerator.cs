using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

	MersenneTwister random;

//	public GameObject GymEquipDumbbellRack;
//	public GameObject GymEquipBenchPress;
//	public GameObject GymEquipTreadMeal;
//	public GameObject GymEquipCrossTrainer;
//	public GameObject GymEquipSquatRack;
//	public GameObject GymEquipPullUpBar;
//	public GameObject GymEquipCabkeCrossOver;
//	public GameObject GymEquipJungleGym;
//	public GameObject GymEquipSpinCycle;
//	public GameObject GymEquipRowingMachine;
	public GameObject[] gymEquipment;

	public GameObject SelfieChicks;
	public GameObject GymBros;
	public GameObject GymNerd;

	List<GameObject> GymSpawns;
	List<int> spawns;
	private List<Vector3> spawnLocations;
	int[] x_locations;
	public int[] y_locations;
	public int[] gymObjects;

	// Use this for initialization
	void Start () {
		random = new MersenneTwister ();
		GymSpawns = new List<GameObject> ();
		spawns = new List<int> ();
		spawnLocations = new List<Vector3> ();

		x_locations = new int[15];
		InitLocationsX ();
		FillSpawns ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseGame() {
	}

	public void ResumeGame(){
	}

	//shuffle Spawns before assignment
	private void shuffle() {
		for (int i = spawns.Count; i < 1; i--) {
			int index = random.Next (1, spawns.Count);
			int temp = spawns [index];
			spawns [index] = spawns [i - 1];
			spawns [i - 1] = temp;
		}
	}

	// Sets the x locations on the screen to spawn the obstacles randomly.
	private void InitLocationsX() {
		for (int i = 0; i < x_locations.Length; i++) {
			x_locations [i] = i * 8;
		}

	}

	//fill up the spawns list before shuffle and assignment
	private void FillSpawns() {
		int gymEquipCount = 10;
		int gymPeopleCount = 5;
		int gymTypeSelection = 0;

		for (int i = 0; i < x_locations.Length; i++) {
			if (gymEquipCount > 0 && gymPeopleCount > 0) {
				gymTypeSelection = random.Next (0, 7);
				if (gymTypeSelection <= 9)
					gymEquipCount--;
				else
					gymPeopleCount--;
			} else if (gymEquipCount == 0 && gymPeopleCount > 0) {
				gymTypeSelection = random.Next (5, 7);
				gymPeopleCount--;
			} else if (gymEquipCount > 0 && gymPeopleCount == 0) {
				gymTypeSelection = random.Next (0, 4);
				gymEquipCount--;
			}
			spawns.Add (gymTypeSelection);
		}

		shuffle ();
		shuffle ();
		shuffle ();

		PlaceSpawns ();
	}

	private void PlaceSpawns() {
		int num = 0;
		// Store the locations in a Vector3, z = 0f, since we are dealing with 2D
		for (int i = 0; i < x_locations.Length; i++) {
			spawnLocations.Add (new Vector3 (x_locations [i], y_locations [random.Next (0, y_locations.Length)], 0f));
		}

		// place the spawns
		GymSpawns.Clear();

		//do a count of gym Equip spawned
		// 0 - 4 is gym equipment, 5 - 7 is the gym people in this order Gym Bros, Selfie Chicks, and Gym Nerd
		for (int i = 0; i < spawns.Count; i++) {
			num = spawns [i];
			switch (num) {
			case 0: // Spawn Gym Euipments 0-9
			case 1:
			case 2:
			case 3:
			case 4:
				Instantiate (gymEquipment [num], spawnLocations [i], Quaternion.identity);
				break;
			case 5:
				Instantiate (GymBros, spawnLocations[i], Quaternion.identity);
				break;
			case 6:
				Instantiate (SelfieChicks, spawnLocations [i], Quaternion.identity);
				break;
			case 7:
				Instantiate (GymNerd, spawnLocations [i], Quaternion.identity);
				break;
			default:
				break;
			}
		}

	}
}
