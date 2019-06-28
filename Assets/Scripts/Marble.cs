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
	void Update ()
    {
		if(transform.position.y < -5)
        {
            MarbleLost();
        }
	}

    public IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(1f);

        transform.position = startPos;
    }

    void MarbleLost()
    {
        transform.position = new Vector3(80f,50f,0);

        if (board.Lives == null)
        {
            StartCoroutine(ResetPos());
        }
        else if (board.Lives > 0)
        {
            board.Lives -= 1;
            StartCoroutine(ResetPos());
        }
        else if(board.Lives == 0)
        {
            board.LevelFailed();
        }
    }

    
}
