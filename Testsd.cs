using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testsd : MonoBehaviour {

	public GameObject particlePrefab;
	private GameObject particleSigned;
	void Start () {
		particleSigned = Instantiate(particlePrefab) as GameObject;
	}
		float s;
	void Update () {
		particleSigned.transform.position = new Vector3(2+s,2,0);
		s+=0.01f;
		
	}
}
