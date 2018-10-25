using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public Text persLoc;

    public LevelGroupScript levels;


    private string path;

    // Use this for initialization
    void Start () {
        //persLoc.text = "Location: " + Application.persistentDataPath;
        path = Application.persistentDataPath + "/";
    }

    private void listFilesInDirectory()
    {
        levels.gameObject.SetActive(true);

        string[] filePaths = Directory.GetFiles(path);

        //foreach (string xfile in filePaths)
        for (int i = 0; i < filePaths.Length; i++)
        {
            string fileName = Path.GetFileName(filePaths[i]);
            // Call function with ^ as param. Creates button with fileName attr
            levels.CreateNewButton(fileName,i);
        }
    }

    public void PlayGameButton()
    {
        listFilesInDirectory();
    }

    public void EditorButton()
    {
        SceneManager.LoadScene("EditorMode");
    }

}
