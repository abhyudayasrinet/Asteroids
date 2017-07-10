﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour {



	float screenWidth;
	float screenHeight;
	Transform[] ghosts = new Transform[8];
	bool isVisible;

	// Use this for initialization
	void Start () {


		var cam = Camera.main;

		var screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
		var screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
		//Debug.Log (screenTopRight);
		//Debug.Log (screenBottomLeft);


		screenWidth = (screenTopRight.x - screenBottomLeft.x);
		screenHeight = (screenTopRight.y - screenBottomLeft.y);
		//Debug.Log (screenWidth);
		//Debug.Log (screenHeight);

		CreateGhostShips ();
		PositionGhostShips ();


	}
	
	// Update is called once per frame
	void Update () {
		
		AdvancedScreenWrap ();
	}

	void AdvancedScreenWrap()
	{	
		// Move to separate function
		//var isVisible = false;
		var renderer = GetComponent<Renderer> ();
		if (tag == "Bolt") {
			renderer = GetComponentInChildren<Renderer> ();
		}

		if (renderer.isVisible)
			isVisible = true;
		else
			isVisible = false;

		if(!isVisible)
		{
			SwapShips();
			isVisible = true;
		}
	}

	void CreateGhostShips()
	{
		for(int i = 0; i < 8; i++)
		{
			ghosts[i] = Instantiate(transform, Vector3.zero, Quaternion.identity) as Transform;

			DestroyImmediate(ghosts[i].GetComponent<ScreenWrapper>());
		}
	}

	void SwapShips()
	{
		foreach (var ghost in ghosts) 
		{
			if (ghost.position.x < screenWidth && ghost.position.x > -screenWidth
			   && ghost.position.y < screenHeight && ghost.position.y > -screenHeight) 
			{
				transform.position = ghost.position;
				break;
			}
		}
		PositionGhostShips ();
	}
		
	void PositionGhostShips()
	{
		// All ghost positions will be relative to the ships (this) transform,
		// so let's star with that.
		var ghostPosition = transform.position;

		// We're positioning the ghosts clockwise behind the edges of the screen.
		// Let's start with the far right.
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[0].position = ghostPosition;

		// Bottom-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[1].position = ghostPosition;

		// Bottom
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[2].position = ghostPosition;

		// Bottom-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[3].position = ghostPosition;

		// Left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[4].position = ghostPosition;

		// Top-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[5].position = ghostPosition;

		// Top
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[6].position = ghostPosition;

		// Top-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[7].position = ghostPosition;

		// All ghost ships should have the same rotation as the main ship
		for(int i = 0; i < 8; i++)
		{
			ghosts[i].rotation = transform.rotation;
		}
	}
}
