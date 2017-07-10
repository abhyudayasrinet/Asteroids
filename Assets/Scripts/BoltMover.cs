using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour {

	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
		Debug.Log ("bolt created");
		var rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = rigidbody.transform.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
