using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showSliderValueController : MonoBehaviour {

	Text valueText;
	public string typeOfValue;
	public bool round;

	void Start(){
		valueText = GetComponent<Text>();
	}

	public void valueUpdate(float value){
		if(round){
			valueText.text = Mathf.RoundToInt(value) + " " + typeOfValue;
		}
		else{
			valueText.text = value + " " + typeOfValue;
		}
	}
}
