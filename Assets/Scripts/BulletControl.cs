using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

	public float speed = 0.4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(0, 0, speed);
		if (this.transform.position.z > PlaneControl.limitMaxZ + 5) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerStay(Collider obj) {
		Debug.Log(obj.name);
		if (obj.gameObject.GetComponent<Emery>() != null) {
			obj.gameObject.GetComponent<Emery>().hited();
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision obj)
	{
		Debug.Log(obj.collider.name);
		if (obj.collider.gameObject.GetComponent<Emery>() != null)
		{
			obj.collider.gameObject.GetComponent<Emery>().hited();
			GameManager.Score();
			Destroy(this.gameObject);
		}
	}
}
