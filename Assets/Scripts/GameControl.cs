using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject altScreen;
    public GameObject levelComplete;
    public GameObject pauseButton;
    public GameObject gameOverScreen;

    // Lives are for when checkpoints are implemented. Loose a ball and lose a life.
    //Run out of lives and have to restart level. [ GameSetUp ] will check if a checkpoint tile was
    // created, if so lives will be implemented. Otherwise lives will not be used and a game over can not occur
    // May add a death counter
    public int? maxLives;
    private int? lives;
    public int? Lives { get { return lives; } set { lives = value; } }

    void Start ()
    {
        maxLives = 3;
        lives = maxLives;
	}
	
	
    public void LevelComplete()
    {
        altScreen.SetActive(true);
        levelComplete.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void LevelFailed()
    {
        altScreen.SetActive(true);
        gameOverScreen.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    } 

    public void RestartLevel()
    {
        lives = maxLives;
        StartCoroutine(GameObject.Find("Marble").GetComponent<Marble>().ResetPos());
    }

}
