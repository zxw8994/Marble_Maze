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
            //GameObject.Find("PauseButton").SetActive(false);
            //altScreen.SetActive(true);
            //levelComplete.SetActive(true);
            //Time.timeScale = 0;
            gc.LevelComplete();
        }
    }

}
