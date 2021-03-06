﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingBricks : MonoBehaviour {

	public GameObject preFabGreenBrick;
	public GameObject preFabBlueBrick;
	public GameObject preFabPinkBrick;
	public GameObject preFabYellowBrick;
	public GameObject preFabUnbreakableBrick;

	private float constantSeparator = 1.25f;
	private float posX = -8.2f;
	private float posY = 4.5f;

	public static int numBricks = 0;
	public static List <GameObject> brickList = new List<GameObject>();

	private int bricksPerRow = 13;
	private int countBricksInRow = 1;
	private int blackBricksCount = 0;

	void Start () {

		var bricks = Resources.LoadAll<GameObject>("PreFabsBricks");

		for (int i = 0; i < 85; i++) {

			
			//Escolhe aleatóriamente um tipo de brick da lista
			int indexBrick = getRandomBricksColor(); 

			//Brick Preto (Unbreakable) somente após a terceira linha 
			while (indexBrick == 3 && i <= 28) {
				indexBrick = getRandomBricksColor();
			}


			if (indexBrick == 3) {
				blackBricksCount++;

				//Somente 3 Unbreakable na Tela
				while (blackBricksCount > 3 && indexBrick == 3) {
					indexBrick = getRandomBricksColor();
				}
			}

			//Cria o GameObject e adiciona na lista
			GameObject lo = (GameObject)bricks [indexBrick];
			brickList.Add (lo);

		}
				
		transform.position = new Vector2 (posX, posY);
		Score.pontos = brickList.Capacity;
	}

	int getRandomBricksColor(){
		return Random.Range (0, 5	); 
	}

	void SpawnObjects() 
	{    
		GameObject myObj = Instantiate (brickList [numBricks]) as GameObject;
		myObj.transform.position = transform.position;
	}

	void Update() 
	{
		if (numBricks < brickList.Count-1) {
			SpawnObjects ();
			transform.position = new Vector2 (posX + constantSeparator, posY);
			posX = posX + constantSeparator;

			if (countBricksInRow == bricksPerRow) {
				posY = posY - 0.6f;
				posX = -9.45f;
				countBricksInRow = 0;
			} else {
				countBricksInRow++;
			}
				
			numBricks++;
		}
	}
}
