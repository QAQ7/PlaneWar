using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : Emery {

	public float speed = -1;

    public override void hited()
    {
		Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(0, 0, speed);
		if (this.transform.position.z < PlaneControl.limitMinZ) {
			Destroy(this.gameObject);
		}
	}
}
