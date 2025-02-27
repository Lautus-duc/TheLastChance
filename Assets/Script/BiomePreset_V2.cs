using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "BiomePreset_V2", menuName = "MyGame/BiomePreset_V2")]
public class BiomePreset_V2 : ScriptableObject
{
    public Tile[] tiles;
    public float minHeight;
    public float minMoisture;
    public float minHeat;

    public bool IsCollidered;

    public Tile GetTileSprite()
    {
        int l = Random.Range(0, tiles.Length);
        return tiles[l];
    }

    public bool MatchCondition(float height, float moisture, float heat)
    {
        return height >= minHeight && moisture >= minMoisture && heat >= minHeat;
    }
}
