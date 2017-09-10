using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Rigidbody2D ball;
	public float force;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody2D> ();
		ball.AddForce (new Vector2 (1f, 0.5f) * Time.deltaTime * force);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
