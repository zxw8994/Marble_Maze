using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTileScript : MonoBehaviour {

    GameObject altScreen;
    GameObject levelComplete;

    private void Start()
    {
        altScreen = GameObject.Find("AltScreenBase");
        levelComplete = GameObject.Find("LevelCompleteScreen");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Marble")
        {
            altScreen.SetActive(true);
            levelComplete.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
