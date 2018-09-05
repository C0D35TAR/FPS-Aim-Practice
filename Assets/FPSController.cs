﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float speed = 2f;
    public float sensitivity = 2f;
    CharacterController player;

    public GameObject eyes;

    private float moveWS;
    private float moveAD;

    private float rotX;
    private float rotY;

	// Use this for initialization
	void Start ()
    {
        player = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        moveWS = Input.GetAxis("Vertical") * speed;
        moveAD = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 movement = new Vector3(moveAD, 0, moveWS);
        transform.Rotate(0, rotX, 0);
        eyes.transform.Rotate(-rotY, 0, 0);

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
    }
}