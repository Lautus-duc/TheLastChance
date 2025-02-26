using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "BiomePreset", menuName = "MyGame/BiomePreset")]
public class BiomePreset : ScriptableObject
{
    public Sprite[] tiles;
    public float minHeight;
    public float minMoisture;
    public float minHeat;

    public Sprite GetTileSprite()
    {
        int l = Random.Range(0, tiles.Length-1);
        return tiles[l];
    }

    public bool MatchCondition(float height, float moisture, float heat)
    {
        return height >= minHeight && moisture >= minMoisture && heat >= minHeat;
    }
}
