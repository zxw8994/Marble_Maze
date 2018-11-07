using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject altScreen;
    public GameObject levelComplete;
    public GameObject pauseButton;

    // Use this for initialization
    void Start () {
		
	}
	
	
    public void LevelComplete()
    {
        altScreen.SetActive(true);
        levelComplete.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

}
