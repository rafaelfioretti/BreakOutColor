using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour {

	public GameObject lostLifeSound;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		Instantiate (lostLifeSound, transform.position, transform.rotation);
		Life.vidas = Life.vidas - 1;
		if (Life.vidas == 0) {
			SceneManager.LoadScene ("Intro");
		}
	}
}
