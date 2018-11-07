using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour {

    GameControl board;
    public Vector3 startPos;

	// Use this for initialization
	void Start () {
        board = GameObject.Find("GameManager").GetComponent<GameControl>();

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -5)
        {
            ResetPos();
        }
	}

    void ResetPos()
    {
        transform.position = startPos;
    }
}
