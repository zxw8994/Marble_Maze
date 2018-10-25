using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EditorControl : MonoBehaviour {

    private bool tileSelected = false;
    public bool TileSelected { get { return tileSelected; } set { tileSelected = value; } }

    private BoardTile selectedTile;
    public BoardTile SelectedTile { get { return selectedTile; } set{ selectedTile = value; } }

    private GameSetUp setUp;

    public GameObject buttonGroup;
    private RectTransform buttonGroupTrans;
    private float travelTime = 5f;
    private float currentTime = 0;
    private float normalizedValue;

    public Text rotationText;
    private int rotationMod = 1;

    public bool isStartTile = false;
    public bool isEndTile = false;

    public bool isPaused = false;

    // Use this for initialization
    void Start () {
        setUp = FindObjectOfType<GameSetUp>();

        buttonGroupTrans = buttonGroup.GetComponent<RectTransform>();
	}

    private void Update()
    {
        rotationText.text = " " + buttonGroupTrans.localRotation.x + "    " + buttonGroupTrans.localRotation.y + "    " + buttonGroupTrans.localRotation.z + "    " + buttonGroupTrans.localRotation.w;
    }

    // Try translating localPosition of each child (button) in the Button Group
    public void MoveSliderRight()
    {
        if (!isPaused)
        {
            //if (buttonGroupTrans.localPosition.x < 0)
            //{
            buttonGroupTrans.localPosition = new Vector3(buttonGroupTrans.localPosition.x - 184, buttonGroupTrans.localPosition.y, 0);
            //}
        }
    }

    public void MoveSliderLeft()
    {
        if (!isPaused)
        {
            if (buttonGroupTrans.localPosition.x < 0)
            {
                buttonGroupTrans.localPosition = new Vector3(buttonGroupTrans.localPosition.x + 184, buttonGroupTrans.localPosition.y, 0);
            }
        }
    }

    public void RotateClockwise()
    {
        if (!isPaused)
        {
            if (rotationMod == 3)
            {
                rotationMod = 0;
            }
            else rotationMod += 1;
        }
    }

    public void RotateCounterClockwise()
    {
        if (!isPaused)
        {
            if (rotationMod == 0)
            {
                rotationMod = 3;
            }
            else rotationMod -= 1;
        }
    }


    public void MakeEmptyTile()
    {
        if (!isPaused)
        {
            if (tileSelected)
            {
                ReplaceTile(setUp.emptyTilePrefab, TileType.Empty);

            }
        }
    }

    public void MakeHoleTile()
    {
        if (!isPaused)
        {
            if (tileSelected)
            {
                ReplaceTile(setUp.holeTilePrefab, TileType.Hole);

            }
        }
    }

    public void MakeSingleSideWallTile()
    {
        if (!isPaused)
        {
            if (tileSelected)
            {
                ReplaceTile(setUp.SingleSideWallTilePrefab, TileType.SingleSideWall);

            }
        }
    }

    public void MakeDoubleSideWallTile()
    {
        if (!isPaused)
        {
            if (tileSelected)
            {
                ReplaceTile(setUp.DoubleSideWallTilePrefab, TileType.DoubleSideWall);

            }
        }
    }

    public void MakeCornerWallTile()
    {
        if (!isPaused)
        {
            if (tileSelected)
            {
                ReplaceTile(setUp.CornerWallTilePrefab, TileType.CornerWall);

            }
        }
    }

    public void MakeHoleSingleWallTile()
    {
        if (!isPaused)
        {
            if (tileSelected)
            {
                ReplaceTile(setUp.holeSingleWallTilePrefab, TileType.HoleSingleWall);

            }
        }
    }

    public void MakeHoleCornerWallTile()
    {
        if (!isPaused)
        {
            if (tileSelected)
            {
                ReplaceTile(setUp.holeCornerWallTilePrefab, TileType.HoleCornerWall);

            }
        }
    }

    public void MakeStartEmptyTile()
    {
        if (!isPaused)
        {
            if (tileSelected && !isStartTile)
            {
                ReplaceTile(setUp.StartEmptyTilePrefab, TileType.StartEmpty);
                isStartTile = true; // STILL NEED TO CHECK WHEN LOADING LVL FILE FOR MORE THAN ONE START TILE


            }
            else if (tileSelected && !isStartTile) { tileSelected = false; selectedTile = null; }
        }
    }

    public void MakeEndEmptyTile()
    {
        if (!isPaused)
        {
            if (tileSelected)
            {
                ReplaceTile(setUp.EndEmptyTilePrefab, TileType.ExitEmpty);
                isEndTile = true;

            }
        }
    }

    
    public void ReplaceTile(BoardTile tile, TileType bType)
    {
        BoardTile newTile = Instantiate(tile) as BoardTile;
        setUp.tiles[selectedTile.coordinates.x, selectedTile.coordinates.z] = newTile;
        newTile.coordinates = selectedTile.coordinates;
        newTile.tileType = bType;
        newTile.name = "Board Tile " + newTile.coordinates.x + ", " + newTile.coordinates.z;
        newTile.transform.parent = selectedTile.transform.parent;
        newTile.rot = rotationMod;
        newTile.transform.localPosition = new Vector3(newTile.coordinates.x - setUp.size.x * 0.5f + 0.5f, 0f, newTile.coordinates.z - setUp.size.z * 0.5f + 0.5f);
        newTile.transform.localRotation = Quaternion.Euler(-90, 90 * rotationMod, 0);
        if (newTile.tileType == TileType.StartEmpty && setUp.StartTile == null)
        {
            setUp.StartTile = newTile;
        }

        Destroy(selectedTile.gameObject);

        tileSelected = false;
        selectedTile = null;
    }
    

}
