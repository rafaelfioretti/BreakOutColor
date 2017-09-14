using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c){
		Debug.Log ("Entrou2!! "+c.gameObject.name);

		if (c.gameObject.name.Contains ("Main_Ball")) {
			SceneManager.LoadScene ("Intro");
		}
	}
}
