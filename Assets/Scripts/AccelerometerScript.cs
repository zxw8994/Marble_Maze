using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerScript : MonoBehaviour {

    public bool isFlat = true;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 tilt = Input.acceleration;


        if (isFlat)
        {
            tilt = Quaternion.Euler(90, Camera.main.transform.rotation.y, 0) * tilt; // didnt work
        }

        rigid.AddForce(tilt * 2.6f);
        //rigid.AddTorque(tilt);

        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.red);
    }

}
