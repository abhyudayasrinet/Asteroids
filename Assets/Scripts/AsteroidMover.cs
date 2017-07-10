using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour {


	public float speed;
	public Vector3 moveDirection;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("movedirection : "+moveDirection);
		transform.Translate (moveDirection * speed * Time.deltaTime, Space.World);
	}
}
