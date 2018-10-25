using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetUp : MonoBehaviour {

    public IntVector2 size;

    public AccelerometerScript marble;

    public BoardTile[,] tiles;

    private BoardTile startTile;
    public BoardTile StartTile
    {
        get { return startTile; }
        set { startTile = value; }
    }

    public BoardTile emptyTilePrefab;
    public BoardTile holeTilePrefab;
    public BoardTile SingleSideWallTilePrefab;
    public BoardTile DoubleSideWallTilePrefab;
    public BoardTile CornerWallTilePrefab;
    public BoardTile holeSingleWallTilePrefab;
    public BoardTile holeCornerWallTilePrefab;
    public BoardTile StartEmptyTilePrefab;
    public BoardTile EndEmptyTilePrefab;

    private bool editorMode = false;
    public bool EditorMode { get { return editorMode; } set { editorMode = value; } }

    LevelFileManager lvlManager;

	// Use this for initialization
	void Start () {
        tiles = new BoardTile[size.x, size.z];
        lvlManager = FindObjectOfType<LevelFileManager>();

        if (GetComponent<EditorControl>())
        {
            Debug.Log("Test-Editor");
            editorMode = true;
            GenerateEditor();
        } else
        {
            XMLManager xml = FindObjectOfType<XMLManager>();
            if (lvlManager.LevelPath != null)
            {
                xml.LoadFile(lvlManager.LevelPath);
            }
        }
        // else bring up Level select menu
        // gets every file in specific folder, path is saved in a list
        // user clicks on (clickable object, button img, etc) corresponding to a specific file in list with data on a lvl
	}
	
	
    public void GenerateTiles()
    {
        Debug.Log("Called GenerateTiles");
        tiles = new BoardTile[size.x, size.z];
        for(int x =0; x < size.x; x++)
        {
            for(int z =0; z < size.z; z++)
            {
                CreateTile(new IntVector2(x, z), emptyTilePrefab, TileType.Empty,1);
                
            }
        }
    }


    public void GenerateEditor()
    {
        Debug.Log("Called GenerateEditor");
        tiles = new BoardTile[size.x, size.z];
        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.z; z++)
            {
                {
                    CreateTile(new IntVector2(x, z), emptyTilePrefab, TileType.Empty,1);
                }
            }
        }
    }


    public void CreateTile(IntVector2 coords, BoardTile tile,TileType bType,int rot)
    {
        BoardTile newTile = Instantiate(tile) as BoardTile;
        tiles[coords.x, coords.z] = newTile;
        newTile.coordinates = coords;
        newTile.rot = rot;
        if(bType == TileType.StartEmpty && startTile == null)
        {
            startTile = newTile;
        }
        newTile.tileType = bType;
        newTile.name = "Board Tile " + coords.x + ", " + coords.z;
        newTile.transform.parent = transform;
        newTile.transform.localPosition = new Vector3(coords.x - size.x * 0.5f + 0.5f, 0f,coords.z - size.z * 0.5f + 0.5f);
        newTile.transform.localRotation = Quaternion.Euler(-90, 90 * rot, 0);
        Debug.Log(newTile.transform.localEulerAngles.x);



    }

    public void CreateMarble()
    {
        AccelerometerScript newMarble = Instantiate(marble);
        newMarble.gameObject.transform.position = startTile.transform.position + new Vector3(0, 5f, 0);

    }

}
