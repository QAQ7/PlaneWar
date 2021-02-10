using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Text>().text = "得分:" + PlayerPrefs.GetInt("score") + "\n最高分" + PlayerPrefs.GetInt("high");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
