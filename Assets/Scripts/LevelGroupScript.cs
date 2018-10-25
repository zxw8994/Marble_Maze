using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelGroupScript : MonoBehaviour {

    // spawns a Level button for each file in StreamingAsset folder
    // button holds string of file dataPath
    public LevelButtonScript buttonPrefab;
    private List<LevelButtonScript> buttonGroup = new List<LevelButtonScript>();

    public void CreateNewButton(string lvlName,int n)
    {
        LevelButtonScript newButton = Instantiate(buttonPrefab, this.transform);
        newButton.FilePath = lvlName;
        buttonGroup.Add(newButton);
        newButton.transform.localPosition = new Vector3(0, (n * -newButton.GetComponent<RectTransform>().rect.height) -30f, 0);//(buttonGroup.Count - 1) - 20f,0);
    }

}
