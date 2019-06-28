using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTileScript : MonoBehaviour {

    GameControl gc;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GM").GetComponent<GameControl>();

        //altScreen.SetActive(false);
        //levelComplete.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Marble")
        {
            gc.LevelComplete();
        }
    }

}
