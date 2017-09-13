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


		if(c.gameObject.name.Contains ("wall")){
			ball.AddForce (new Vector2 (1f, 0.5f) * Time.deltaTime * 0);
			return;
		}
		
		Debug.Log("Game Object = "+c.otherCollider.gameObject);

		GameObject objectball = c.otherCollider.gameObject;




		Animator animator = c.gameObject.GetComponent<Animator>();
		if (animator != null) {

			Debug.Log("Game Object = "+c.gameObject);

			AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (0); //GetCurrentAnimatorStateInfo ();


			if(info.IsName("blue")){
				objectball.GetComponent<Renderer> ().material.color = Color.blue;
				//Destroy(c.gameObject);
			} else if(info.IsName("green")){
				objectball.GetComponent<Renderer>().material.color = Color.green;
				//Destroy(c.gameObject);
			} else if(info.IsName("pink") ){
				objectball.GetComponent<Renderer> ().material.color = new Color32 (100,255,20,147);
				//Destroy(c.gameObject);
			} else if(info.IsName("yellow")){
				objectball.GetComponent<Renderer>().material.color = Color.yellow;
				//Destroy(c.gameObject);
			}else if(info.IsName("super")){
				objectball.GetComponent<Renderer>().material.color = Color.grey;
				//Destroy(c.gameObject);
			}

			//Debug.Log ("velocidade = " + ball.velocity.magnitude);
 
		}


		Debug.Log("Color = "+objectball.GetComponent<Renderer> ().material.color);

		if (c.gameObject.name.Contains ("preFabBlueBrick") &&
			objectball.GetComponent<Renderer> ().material.color == Color.blue) {
			Destroy(c.gameObject);
			ScorePoint ();

		} else if(c.gameObject.name.Contains ("preFabGreenBrick") &&
			objectball.GetComponent<Renderer> ().material.color == Color.green) {
			Destroy(c.gameObject);
			ScorePoint ();

		} else if(c.gameObject.name.Contains ("preFabYellowBrick") &&
			objectball.GetComponent<Renderer> ().material.color == Color.yellow) {
			Destroy(c.gameObject);
			ScorePoint ();

		} else if(c.gameObject.name.Contains ("preFab") &&
			objectball.GetComponent<Renderer> ().material.color == Color.grey) {
			Destroy(c.gameObject);
			ScorePoint ();
		} 

	}

	void ScorePoint(){
		Score.pontos++;
	}
}

