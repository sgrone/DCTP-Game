/* This script controls movement, rotation, and zooming
   of camera while in third person */

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ThirdPMovement : MonoBehaviour
{
    //public float speedH = 2.0f;
    //public float speedV = 2.9f;

    //private float yaw = 0.0f;
    //private float pitch = 0.0f;
	
	public float moveSpeed;
	public float zoomSpeed;
	public float minZoomDist;
	public float maxZoomDist;
	public float rotateSpeed = 0.1f;
	
	Vector2 p1;
	Vector2 p2;
	
	public Camera cam;

    // Start is called before the first frame update
    private void Awake() {
		cam = Camera.main;
    }
	
    // Update is called once per frame
    void Update() {
		// Actual movement
		Move();
		Rotate();
		Zoom();
    }
	
	// Movement with WASD keys
	void Move () {
		float xInput = Input.GetAxis("Horizontal");
		float zInput = Input.GetAxis("Vertical");
		transform.position += new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, zInput * moveSpeed * Time.deltaTime);
		
		//TO_DO Update this method so that 'forward' moves in the direction that camera is facing
	}
	
	// Uses middle mouse scroll button to rotate screen
	void Rotate() {
		if (Input.GetMouseButtonDown(2)) {
			p1 = Input.mousePosition;
		}
		
		if (Input.GetMouseButton(2)) {
			p2 = Input.mousePosition;
			
			float dx = (p2 - p1).x * rotateSpeed * Time.deltaTime;
			float dy = (p2 - p1).y * rotateSpeed * Time.deltaTime;
			
			transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0));
			
		}
	}
	
	// Scroll wheel used to zoom in and out
	void Zoom() {
		float scrollInput = Input.GetAxis("Mouse ScrollWheel");
		float dist = Vector3.Distance(transform.position, cam.transform.position);
		
		// TO_DO - These should restrict how close/far you can zoom
		// Currently broken, not sure why
		//if (dist < minZoomDist && scrollInput > 0.0f)
			//return;
		//else if (dist > maxZoomDist && scrollInput < 0.0f)
			//return;
		
		cam.transform.position += cam.transform.forward * scrollInput * zoomSpeed;
			
	}
}

