using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFileManager : MonoBehaviour {

    public static LevelFileManager instance;

    private static string levelPath;

    private void Awake()
    {
        // set so this persists on scene change

        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public string LevelPath
    {
        get { return levelPath; }
        set { levelPath = value; }
    }


}
