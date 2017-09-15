using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int pontos;
	public Text txtPontos;


	// Update is called once per frame
	void Update () {
		txtPontos.text  = pontos.ToString();
	}
}
