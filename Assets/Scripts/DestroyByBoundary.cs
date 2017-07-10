using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//destroy anything that goes out of the boundary
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
}
