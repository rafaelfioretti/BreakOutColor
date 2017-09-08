using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingBricks : MonoBehaviour {

	public GameObject preFabGreenBrick;
	public GameObject preFabBlueBrick;
	public GameObject preFabPinkBrick;
	public GameObject preFabYellowBrick;
	public GameObject preFabUnbreakableBrick;

	private float constantSeparator = 1.25f;
	private float posX = -6.89f;
	private float posY = 5.5f;

	public static int numBricks = 0;
	public static List <GameObject> brickList = new List<GameObject>();

	private int bricksPerRow = 11;
	private int countBricksInRow = 1;

	// Use this for initialization
	void Start () {

		var bricks = Resources.LoadAll<GameObject>("PreFabsBricks");

		//Cabem 12 bricks em cada inha
		for (int i = 0; i < 73; i++) {
	
			//Escolhe aleatóriamente um tipo de brick da lista
			int indexBrick = Random.Range (0, 5	); 

			//Cria o GameObject e adiciona na lista
			GameObject lo = (GameObject)bricks[indexBrick];
			brickList.Add(lo);
		}
				
		transform.position = new Vector2 (posX, posY);
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
				posX = -8.14f;
				countBricksInRow = 0;
			} else {
				countBricksInRow++;
			}
				
			numBricks++;
		}
	}
}
