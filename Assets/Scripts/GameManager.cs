using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float timeGrap = 0.4f;
	public float time = 0;
	public GameObject[] emerys;
	public static int score = 0;
	public static bool gameEnd = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!gameEnd)
		if (Time.time - time >= timeGrap)
		{
			Instantiate(emerys[Random.Range(0, emerys.Length)], new Vector3(Random.Range(PlaneControl.limitMinX,PlaneControl.limitMaxX),-2.5f,PlaneControl.limitMaxZ+8), emerys[Random.Range(0, emerys.Length)].transform.rotation);
			time = Time.time;
		}
	}

	public static void GameEnd() {
		gameEnd = true;
		string path = System.Environment.CurrentDirectory + @"\save";
		string filescore = File.ReadAllText(path);
		int high = int.Parse(filescore);
		if (score > high) {
			File.WriteAllText(path, score.ToString());
			high = score;
		}
		PlayerPrefs.SetInt("high", high);
		PlayerPrefs.SetInt("score", score);
		SceneManager.LoadScene("endScene");
	}

	public static void Score() {
		score++;
	}
}
