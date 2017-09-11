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

	void OnCollisionEnter2D(Collision2D c){
		//bool b = c.gameObject.CompareTag ("preFabBlueBrick");
		Debug.Log("Game Object = "+c.otherCollider.gameObject);

		GameObject ball = c.otherCollider.gameObject;


		Animator animator = c.gameObject.GetComponent<Animator>();
		if (animator != null) {

			Debug.Log("Game Object = "+c.gameObject);

			AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (0); //GetCurrentAnimatorStateInfo ();
 
			//Debug.Log("Name = "+info.);

			//c.gameObject.name.Contains("preFabBlueBrick")

			ball.GetComponent<Renderer>().material.color = Color.yellow;


//			if(info.IsName("blue")){
//				ball.GetComponent<Renderer> ().material.color = Color.blue;
//				//Destroy(c.gameObject);
//			} else if(info.IsName("green")){
//				ball.GetComponent<Renderer>().material.color = Color.green;
//				//Destroy(c.gameObject);
//			} else if(info.IsName("pink") ){
//				ball.GetComponent<Renderer> ().material.color = Color.grey;
//				//Destroy(c.gameObject);
//			} else if(info.IsName("yellow")){
//				ball.GetComponent<Renderer>().material.color = Color.yellow;
//				//Destroy(c.gameObject);
//			}

		}


		 
	}
}
