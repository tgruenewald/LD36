﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void click() {
		SceneManager.LoadScene ("office");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
