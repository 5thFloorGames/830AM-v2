﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/FPS translate")]
public class FPS_translate : MonoBehaviour
{

    public float speed = 1.0f;
    public bool active = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (active)
        {

            Quaternion cameraRotation = this.transform.rotation;

            Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
            float tmp = Input.GetAxis("Vertical") * speed;
            movement.z = tmp;
            tmp = Input.GetAxis("Horizontal") * speed;
            movement.x = tmp;

            movement = cameraRotation * movement;
            movement.y = 0.0f;

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.AddForce(movement);

            //this.transform.position += movement * Time.deltaTime;
        }

    }

  
}
