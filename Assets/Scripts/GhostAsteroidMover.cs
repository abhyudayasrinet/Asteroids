using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAsteroidMover : MonoBehaviour {


	public Vector3 moveDirection;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (moveDirection * speed * Time.deltaTime, Space.World);
	}
}
