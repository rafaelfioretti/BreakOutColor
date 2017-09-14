using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enter : MonoBehaviour {

	public Button btnInit;
	Button btn;

	// Use this for initialization
	void Start () {
		btn = btnInit.GetComponent<Button> ();
		btn.onClick.AddListener (EnterGame);
	}
	
		
	void EnterGame(){
		SceneManager.LoadScene ("Game");
	}
}
