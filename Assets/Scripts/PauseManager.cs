using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public GameObject panelGroup;
    public GameObject pauseGroup;
    private EditorControl EC;

    private void Start()
    {
        EC = FindObjectOfType<EditorControl>();
    }

    public void PauseGame()
    {
        if (!pauseGroup.activeSelf)
        {
            if (panelGroup != null) panelGroup.SetActive(true);

            pauseGroup.SetActive(true);
            EC.isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            if (panelGroup != null) panelGroup.SetActive(false);

            pauseGroup.SetActive(false);
            EC.isPaused = false;
            Time.timeScale = 1;
        }
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
