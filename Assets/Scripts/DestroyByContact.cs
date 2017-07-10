using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary") 
			return;
		Debug.Log ("other : " + other.tag);
		Debug.Log ("self : " + tag);
		if (other.tag == "Asteroid") {
			Destroy (other.gameObject);
			Destroy (gameObject);
			Debug.Log ("Destoryed!");
		}


	}
}
