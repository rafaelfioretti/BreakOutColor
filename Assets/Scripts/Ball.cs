using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	Rigidbody2D ball;
	public float force;
	public GameObject ploopSound;
	public GameObject barra;

	// Use this for initialization
	void Start () {
		Score.pontos = 0;

		ball = GetComponent<Rigidbody2D> ();
		ball.AddForce (new Vector3 (1f, 0.5f) * Time.deltaTime * force);
	}

	// Update is called once per frame
	void Update () {
	}


	void OnCollisionEnter2D(Collision2D c){
		//avoid the ball to be stucked horizontally
		if(c.gameObject.name.Contains ("wall")){
			ball.AddForce (new Vector3 (1f, 0.5f) * Time.deltaTime * 0);
			return;
		}
 
		GameObject objectball = c.otherCollider.gameObject;
 
		//change the ball's color according to brick that has been hit.
		Animator animator = c.gameObject.GetComponent<Animator>();
		if (animator != null) {
			AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo (0);

			if(info.IsName("blue")){
				objectball.GetComponent<Renderer> ().material.color = Color.blue;
			} else if(info.IsName("green")){
				objectball.GetComponent<Renderer>().material.color = Color.green;
			} else if(info.IsName("pink") ){
				objectball.GetComponent<Renderer> ().material.color = Color.magenta;
			} else if(info.IsName("yellow")){
				objectball.GetComponent<Renderer>().material.color = Color.yellow; 
			}else if(info.IsName("super")){
				objectball.GetComponent<Renderer>().material.color = Color.grey;
			}

		}

		//Check if brick hit has the same color of ball, if so destroy object and score
		if (c.gameObject.name.Contains ("preFabBlueBrick") &&
			objectball.GetComponent<Renderer> ().material.color == Color.blue) {
			ScorePoint(c.gameObject);
		} else if(c.gameObject.name.Contains ("preFabGreenBrick") &&
			objectball.GetComponent<Renderer> ().material.color == Color.green) {
			ScorePoint(c.gameObject);
		} else if(c.gameObject.name.Contains ("preFabYellowBrick") &&
			objectball.GetComponent<Renderer> ().material.color == Color.yellow) {
			ScorePoint(c.gameObject);
		} else if(c.gameObject.name.Contains ("preFabPinkBrick") &&
			objectball.GetComponent<Renderer> ().material.color == Color.magenta) {
			ScorePoint(c.gameObject);
		} else if(!c.gameObject.name.Contains ("Unbreakable") && !c.gameObject.name.Contains ("Bat_Principal") &&
			objectball.GetComponent<Renderer> ().material.color == Color.grey) {
			ScorePoint(c.gameObject);
		} 
	}

	//destroy and score
	void ScorePoint(GameObject go){
		Instantiate (ploopSound, transform.position, transform.rotation);
		Destroy(go);
		Score.pontos += 10;
	}


	void OnTriggerEnter2D(Collider2D c){
		ball.velocity = Vector3.zero;
		ball.transform.position = new Vector2 (-0.24f,-1.36f);
		barra.transform.position = new Vector2 (-0.22f,-3.32f);
		ball.AddForce (new Vector3 (1f, 0.5f) * Time.deltaTime * 2);
	}

}
