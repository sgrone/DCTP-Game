using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public float speedH = 2.0f;
    //public float speedV = 2.9f;

    //private float yaw = 0.0f;
    //private float pitch = 0.0f;
	
	public float moveSpeed;
	public float zoomSpeed;
	public float minZoomDist;
	public float maxZoomDist;
	public float rotateSpeed;
	
	Vector2 p1;
	Vector2 p2;
	
	public Camera cam;

    // Start is called before the first frame update
    private void Awake() {
		Debug.Log("cool");
		cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {
		// Mouse camera movement
        //yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");
        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		
		// Actual movement
		Move();
		Rotate();
		Zoom();
    }
	
	void Move () {
		float xInput = Input.GetAxis("Horizontal");
		float zInput = Input.GetAxis("Vertical");
		
		//Vector3 dir = transform.forward * zInput + transform.right * xInput;
		//transform.position += dir * moveSpeed * Time.deltaTime;
		
		transform.position += new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, zInput * moveSpeed * Time.deltaTime);
	}
	
	void Rotate() {
		if (Input.GetMouseButtonDown(2)) {
			Debug.Log("middle mouse click");
			p1 = Input.mousePosition;
		}
		
		if (Input.GetMouseButtonDown(2)) {
			p2 = Input.mousePosition;
			
			float dx = (p2 - p1).x * rotateSpeed;
			float dy = (p2 - p1).y * rotateSpeed;
			
			cam.transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0));
		}
	}
	
	void Zoom() {
		float scrollInput = Input.GetAxis("Mouse ScrollWheel");
		float dist = Vector3.Distance(transform.position, cam.transform.position);
		
		// TO DO - These should restrict how close/far you can zoom
		// Currently broken, not sure why
		//if (dist < minZoomDist && scrollInput > 0.0f)
			//return;
		//else if (dist > maxZoomDist && scrollInput < 0.0f)
			//return;
		
		cam.transform.position += cam.transform.forward * scrollInput * zoomSpeed;
			
	}
}

