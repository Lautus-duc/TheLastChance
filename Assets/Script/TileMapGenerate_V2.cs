using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapGenerate_V2 : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap tilemap2;
    public TilemapCollider2D tilemapCollider2;


    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }


    public void SetMap(Tile tile, int x, int y,bool isCol){
    Vector3Int position = new Vector3Int(x, y, 0);
    if (isCol){
        tilemap2.SetTile(position, tile);
    }
    tilemap.SetTile(position, tile);

    }


    public Tile GetMap(int x, int y){
        Vector3Int position = new Vector3Int(x, y, 0);
        Tile t = tilemap.GetTile<Tile>(position);
        return t;
    }
}

