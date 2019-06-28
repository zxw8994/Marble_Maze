using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraMobileControl : MonoBehaviour {

    //public bool rightButton = false;
    private bool rightPressed = false;
    private bool leftPressed = false;
    public Camera cam;
    public GameObject rotatePoint;
    AccelerometerScript accel;

    private void Start()
    {
        accel = GameObject.Find("Marble").GetComponent<AccelerometerScript>();
    }

    private void Update()
    {
        if (rightPressed && !leftPressed)
        {
            cam.transform.RotateAround(rotatePoint.transform.position, Vector3.up, 50.0f * Time.deltaTime);

        }
        if (leftPressed && !rightPressed)
        {
            cam.transform.RotateAround(rotatePoint.transform.position, Vector3.up, -50.0f * Time.deltaTime);

        }
    }

    public void pressedRotateCounter()
    {
        //cam.transform.RotateAround(rotatePoint.transform.position, Vector3.up, 50.0f * Time.deltaTime);
        rightPressed = true;
    }
    public void releaseRotateCounter()
    {
        rightPressed = false;
    }


    public void pressedRotateClockwise()
    {
        //cam.transform.RotateAround(rotatePoint.transform.position, Vector3.up, -50.0f * Time.deltaTime);
        leftPressed = true;
    }
    public void releasedRotateClockwise()
    {
        leftPressed = false;
    }

    /*private void OnMouseDown()
    {
        if (rightButton && !rightPressed)
        {
            //cam.transform.RotateAround(rotatePoint.transform.position, Vector3.up, 50.0f * Time.deltaTime);
            rightPressed = true;

        }
        else if(!rightButton && !leftPressed)
        {
            //cam.transform.RotateAround(rotatePoint.transform.position, Vector3.up, -50.0f * Time.deltaTime);
            leftPressed = true;
        }
    }
    private void OnMouseUp()
    {
        if (rightPressed)
        {
            rightPressed = false;
        }
        if (leftPressed)
        {
            leftPressed = false;
        }
    }*/

}
