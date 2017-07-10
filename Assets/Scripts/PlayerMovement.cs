using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	public int health;
	public float acceleration = 1.0f;

	public GameObject bolt;
	Transform boltSpawn;

	public float fireRate = 1.5f;
	public bool fireShots;
	float nextFire = 0f;

	// Use this for initialization
	void Start () {
		boltSpawn = transform.Find ("BoltSpawn").transform;
		Debug.Log ("boltspawn: "+boltSpawn.position);
		fireShots = true;
	}

	// Update is called once per frame
	void Update () {
		MovePlayer ();
		if (Input.GetKey (KeyCode.Space)) {
			ShootBolt ();
		}
		if (Input.GetMouseButtonDown (0)) {
			ShootBolt ();
		}
	}

	void ShootBolt() {
		//fire shot if within firerate
		if (fireShots && Time.time > nextFire) {
			Debug.Log ("shoot");
			nextFire = Time.time + fireRate;
			GameObject obj = Instantiate (bolt, boltSpawn.transform.position, boltSpawn.transform.rotation);
			DestroyImmediate(obj.GetComponent<ScreenWrapperBolt>());
		}
	}

	void MovePlayer () {
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			//Increase forward acceleration
			if (acceleration <= 8.0f) {
				acceleration += 0.1f;
			}
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			//Increase backward acceleration
			if (acceleration >= -8.0f) {
				acceleration -= 0.1f;
			}
		}
		else {
			//Decelerate and stop
			if (acceleration > 0.0001f) {
				acceleration -= 0.1f;
			} else if (acceleration < -0.0001f) {
				acceleration += 0.1f;
			} else {
				acceleration = 0.0f;
			}
		}
		//Rotate spaceship
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (transform.up, -100.0f * Time.deltaTime, Space.World);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (transform.up, 100.0f * Time.deltaTime, Space.World);
		}
		transform.Translate (transform.forward * acceleration * Time.deltaTime, Space.World);
	}


}
