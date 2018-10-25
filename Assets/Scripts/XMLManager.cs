using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class XMLManager : MonoBehaviour {

    public static XMLManager ins;
    public GameSetUp gameSU;

    // list of tiles
    public TileDatabase tileDB;
    public InputField inputField;
    public Text warningText;

    private void Awake()
    {
        ins = this;
        //tileDB.list = new List<TileEntry>(gameSU.size.x * gameSU.size.z);
    }



    public void SaveTiles(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TileDatabase));
        //FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/tile_data.xml", FileMode.Create);
        FileStream stream = new FileStream(Application.persistentDataPath + "/" + fileName + ".xml", FileMode.Create);
        //FileStream stream = File.Open(Application.persistentDataPath + "/tile_data.xml", FileMode.Create);
        serializer.Serialize(stream, tileDB);
        stream.Close();
    }

    public void SaveBoard()
    {
        EditorControl ec = FindObjectOfType<EditorControl>();
        if (!ec.isStartTile || !ec.isEndTile)
        {
            warningText.text = "Need to add a Start/End Tile";
            warningText.gameObject.SetActive(true);
            return;
        }
        if(inputField.text == null)
        {
            warningText.text = "Need to Enter a Level Name";
            warningText.gameObject.SetActive(true);
            return;
        }

        foreach(BoardTile bt in gameSU.tiles)
        {
            TileEntry newTile = new TileEntry();
            newTile.tileType = bt.tileType;
            newTile.tileX = bt.coordinates.x;
            newTile.tileZ = bt.coordinates.z;
            newTile.tileRot = bt.rot;
            tileDB.list.Add(newTile);
        }
        SaveTiles(inputField.text);
    }

    // Need a Method to get all files, in a list

    public void LoadFile(string fPath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TileDatabase));
        //FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/XML/tile_data.xml", FileMode.Open);
        //FileStream stream = new FileStream(Application.persistentDataPath + "/tile_data.xml", FileMode.Open);
        FileStream stream = new FileStream(Application.persistentDataPath + "/" + fPath , FileMode.Open);
        tileDB = serializer.Deserialize(stream) as TileDatabase;
        stream.Close();

        LoadTiles(tileDB);
    }

    public void LoadTiles(TileDatabase db)
    {
        bool haveStart = false;
        foreach(TileEntry te in db.list)
        {
            //gameSU.CreateTile(new IntVector2(te.tileX,te.tileZ),)
            switch (te.tileType)
            {
                case TileType.Empty:
                    gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.emptyTilePrefab, te.tileType, te.tileRot);
                    break;
                case TileType.Hole:
                    gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.holeTilePrefab, te.tileType, te.tileRot);
                    break;
                case TileType.SingleSideWall:
                    gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.SingleSideWallTilePrefab, te.tileType, te.tileRot);
                    break;
                case TileType.DoubleSideWall:
                    gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.DoubleSideWallTilePrefab, te.tileType, te.tileRot);
                    break;
                case TileType.CornerWall:
                    gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.CornerWallTilePrefab, te.tileType, te.tileRot);
                    break;
                case TileType.HoleSingleWall:
                    gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.holeSingleWallTilePrefab, te.tileType, te.tileRot);
                    break;
                case TileType.HoleCornerWall:
                    gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.holeCornerWallTilePrefab, te.tileType, te.tileRot);
                    break;
                case TileType.StartEmpty:
                    if (!haveStart)
                    {
                        gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.StartEmptyTilePrefab, te.tileType, te.tileRot);
                        haveStart = true;
                    }else { gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.emptyTilePrefab,TileType.Empty, te.tileRot); }
                    break;
                case TileType.ExitEmpty:
                    gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.EndEmptyTilePrefab, te.tileType, te.tileRot);
                    break;
                default:
                    gameSU.CreateTile(new IntVector2(te.tileX, te.tileZ), gameSU.emptyTilePrefab, TileType.Empty, te.tileRot);
                    break;
            }
        }

        gameSU.CreateMarble();
    }

}

[System.Serializable]
public class TileEntry
{
    public TileType tileType;
    public int tileX;
    public int tileZ;
    public int tileRot;
}

[System.Serializable]
public class TileDatabase
{
    public List<TileEntry> list = new List<TileEntry>();
    
    
}
