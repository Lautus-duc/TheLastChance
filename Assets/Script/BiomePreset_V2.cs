using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "BiomePreset_V2", menuName = "MyGame/BiomePreset_V2")]
public class BiomePreset_V2 : ScriptableObject
{
    public Tile[] tiles;
    public GameObject[] VegetalsGOs;
    public float minHeight;
    public float minMoisture;
    public float minHeat;
    public float minVegetal;
    public int numberOfTheVege;

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

    public int IsVegetalise(float veg){
        if (veg<minVegetal){
            return -1;
        }
        return numberOfTheVege;
    }

    public GameObject GetVegetalGO()
    {
        int l = Random.Range(0, VegetalsGOs.Length);
        return VegetalsGOs[l];
    }
}
