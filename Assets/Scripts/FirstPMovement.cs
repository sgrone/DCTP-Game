/* This class controls movement while in first person view */

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FirstPMovement : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.9f;
	public float moveSpeed = 50f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

	
	// Update is called once per frame
    void Update() {
		CameraMove();
		Move();
    }
	
	void CameraMove() {
		yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
	}
	
	void Move () {
		float xInput = Input.GetAxis("Horizontal");
		float zInput = Input.GetAxis("Vertical");
		transform.position += new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, zInput * moveSpeed * Time.deltaTime);
		
		// TO_DO
		// 'forward' direction should be the same direction that camera is facing
	}
}

