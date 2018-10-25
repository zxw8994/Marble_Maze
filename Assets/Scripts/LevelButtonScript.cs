using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelButtonScript : MonoBehaviour {

    private string filePath;
    Text name;
    LevelFileManager lvlManager;

    private void Start()
    {
        lvlManager = FindObjectOfType<LevelFileManager>();
        name = GetComponentInChildren<Text>();
        name.text = filePath;
    }

    public string FilePath
    {
        get { return filePath; }
        set { filePath = value; }
    }

    public void SelectLevelFile()
    {
        //lvlManager.LevelPath = filePath;
        lvlManager.LevelPath = filePath;
        // switch scene
        SceneManager.LoadScene("Game");
    }

}
