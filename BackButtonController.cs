﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonController : MonoBehaviour {
	public void reSimulate(){
		SceneManager.LoadScene("Simulation");
	}
	public void doexit(){
		Application.Quit();
	}
}
