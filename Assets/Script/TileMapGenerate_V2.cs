using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapGenerate_V2 : MonoBehaviour
{
    public Tilemap tilemap;
    public TilemapCollider2D tilemapCollider;


    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapCollider = tilemap.GetComponent<TilemapCollider2D>();
    }


    public void SetMap(Tile tile, int x, int y){
    Vector3Int position = new Vector3Int(x, y, 0);
    tilemap.SetTile(position, tile);
    Debug.Log(tilemap.GetTile(position));
    }


    public Tile GetMap(int x, int y){
        Vector3Int position = new Vector3Int(x, y, 0);
        Tile t = tilemap.GetTile<Tile>(position);
        return t;
    }


    public void IsCollider (int x, int y, bool actived){
        tilemapCollider.enabled = actived;
    }
}

