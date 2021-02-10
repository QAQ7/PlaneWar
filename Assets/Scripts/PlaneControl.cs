using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour {

	public float speed = 1.0f;
	public static float limitMaxZ = 68;
	public static float limitMaxX = 68;
	public static float limitMinZ = -8;
	public static float limitMinX = -68;
	public float timeGrap = 0.2f;
	public float time = 0.2f;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		time = -1 * timeGrap;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W) && this.transform.position.z <= limitMaxZ) {
			this.transform.position += new Vector3(0, 0, speed);
		}
		if (Input.GetKey(KeyCode.S) && this.transform.position.z >= limitMinZ)
		{
			this.transform.position += new Vector3(0, 0, -1*speed);
		}
		if (Input.GetKey(KeyCode.A) && this.transform.position.x >= limitMinX)
		{
			this.transform.position += new Vector3(-1*speed, 0, 0);
		}
		if (Input.GetKey(KeyCode.D) && this.transform.position.x <= limitMaxX)
		{
			this.transform.position += new Vector3(speed, 0, 0);
		}
		if (Input.GetKey(KeyCode.Space)) {
			if (Time.time - time >= timeGrap) {
				Instantiate(bullet, this.transform.position+bullet.transform.position, bullet.transform.rotation);
				time = Time.time;
			}
		}
	}
	void OnCollisionEnter(Collision obj)
	{
		Debug.Log(obj.collider.name);
		if (obj.collider.gameObject.GetComponent<Emery>() != null)
		{
			Destroy(this.gameObject);
			GameManager.GameEnd();
		}
	}
}
