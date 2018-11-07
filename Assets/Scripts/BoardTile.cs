using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour {

    public IntVector2 coordinates;
    public int rot;
    public TileType tileType;

    public Material ogColor;

    private EditorControl EC;
    private GameSetUp setUp;

    private Color originalColor;

    private void Start()
    {
        EC = FindObjectOfType<EditorControl>();
        setUp = FindObjectOfType<GameSetUp>();
        originalColor = this.gameObject.GetComponent<Renderer>().material.color;//Color.HSVToRGB(36, 255, 86); //new Color(86,52,0,255);  // new Color(36, 255, 86);
    }

    // Can do tile selection by having tile be semi-selected on mouse-down and true-selected on mouse up
    // If Using swipe to rotate camera, can cancel semi-selection when swiping. Unless there is a way to prevent selection when trying to swipe

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
