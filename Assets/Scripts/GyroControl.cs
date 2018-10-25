﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GyroControl : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;

    private Quaternion rot;

    private Transform board;
    private Quaternion rott;

    public Text gyroText;

    private void Start()
    {
        gyroEnabled = EnableGyro();
        board = GetComponent<Transform>();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            board.rotation = Quaternion.Euler(90f, 90f, 0f);
            rott = new Quaternion(0, 0, 1, 0);

            gyroText.text = " YES ";

            return true;
        }
        gyroText.text = " NO ";
        return false;
    }

    private void Update()
    {
        //if (gyroEnabled)
        //{
           // board.localRotation = gyro.attitude * rott;
            Quaternion boardRotation = new Quaternion(Input.gyro.attitude.x + Time.deltaTime, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
            this.transform.rotation = boardRotation;
        //}
    }

    /*
          public GameObject webCameraPlane;

	// Use this for initialization
	void Start () {

        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }

        Input.gyro.enabled = true;

        WebCamTexture webCameraTexture = new WebCamTexture();
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();


	}
	
	// Update is called once per frame
	void Update () {

        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;

	}
    */
}
