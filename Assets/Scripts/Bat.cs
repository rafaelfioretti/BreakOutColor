using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

	public float velocidade;

	Rigidbody2D rb;
	Vector3 posicaoInicial;
	Vector3 posicaoMouse;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		posicaoInicial = transform.position;


		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Fire1")) {
			//Cordenada da tela
			posicaoMouse = Input.mousePosition;

			//Cordeanda do mundo
			posicaoMouse = Camera.main.ScreenToWorldPoint (posicaoMouse);
			posicaoMouse.y = posicaoInicial.y;
			//			posicaoMouse = new Vector3 (
			//				posicaoMouse.x, 
			//				posicaoMouse.y + alturaY, 
			//				posicaoMouse.z);

			//transporta o objeto do ponto A ao ponto B por interpolação
			transform.position = Vector2.Lerp (
				transform.position, 
				posicaoMouse,
				velocidade * Time.deltaTime);

		}

		float mover = Input.GetAxis ("Horizontal") * velocidade * Time.deltaTime;
		transform.Translate (mover, 0.0f, 0.0f);
		
	}
}
