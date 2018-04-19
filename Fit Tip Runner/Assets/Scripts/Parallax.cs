using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Parallax : MonoBehaviour {

	public float speed; // set to 0.001
	float offsetX; // scrolls the background 
	Material mat;

	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		offsetX += CrossPlatformInputManager.GetAxis ("Horizontal") * speed;

		mat.SetTextureOffset ("_MainTex", new Vector2 (offsetX, 0));
	}
}
