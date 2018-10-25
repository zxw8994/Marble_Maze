using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour {

    public IntVector2 coordinates;
    public int rot;
    public TileType tileType;

    private EditorControl EC;
    private GameSetUp setUp;

    private Color originalColor = Color.HSVToRGB(36, 255, 86);

    private void Start()
    {
        EC = FindObjectOfType<EditorControl>();
        setUp = FindObjectOfType<GameSetUp>();
        //originalColor = this.gameObject.GetComponent<Renderer>().material.color;
    }

    private void OnMouseDown()
    {
        if (setUp.EditorMode && !EC.isPaused)
        {
            if (!EC.TileSelected )
            {
                EC.SelectedTile = this;
                EC.TileSelected = true;
                this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            } else if(EC.TileSelected && EC.SelectedTile == this)
            {
                EC.SelectedTile = null;
                EC.TileSelected = false;
                this.gameObject.GetComponent<Renderer>().material.color = originalColor;
            }
        }
    }



}
