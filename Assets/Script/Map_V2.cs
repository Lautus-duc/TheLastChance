using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;


public class Map_V2 : MonoBehaviour
{
    public BiomePreset_V2[] biomes;
    public GameObject tilePrefab;
    public TileMapGenerate_V2 tileMapGenerate;

    [Header("Dimensions")]
    public int width = 50;
    public int height = 50;
    public float scale = 1.0f;
    public Vector2 offset;

    [Header("Height Map")]
    public Wave[] heightWaves;
    public float[,] heightMap;
    [Header("Moisture Map")]
    public Wave[] moistureWaves;
    private float[,] moistureMap;
    [Header("Heat Map")]
    public Wave[] heatWaves;
    private float[,] heatMap;

    void GenerateMap ()
    {
        // height map
        heightMap = NoiseGenerator.Generate(width, height, scale, heightWaves, offset);
        // moisture map
        moistureMap = NoiseGenerator.Generate(width, height, scale, moistureWaves, offset);
        // heat map
        heatMap = NoiseGenerator.Generate(width, height, scale, heatWaves, offset);

        for(int x = 0; x < width; ++x)
        {
            for(int y = 0; y < height; ++y)
            {
                //-----Using the TileMapGenerate-----//
                Tile newTile = GetBiome(heightMap[x, y], moistureMap[x, y], heatMap[x, y]).GetTileSprite();
                tileMapGenerate.SetMap(newTile,x-(height/2),y-(height/2));

                tileMapGenerate.GetMap(x-(height/2),y-(height/2));
            }
        }
        tileMapGenerate.tilemap.RefreshAllTiles();
    }

    void Start ()
    {
        tileMapGenerate = GetComponent<TileMapGenerate_V2>();
        GenerateMap();
    }

    BiomePreset_V2 GetBiome (float height, float moisture, float heat)
    {
        List<BiomeTempData_V2> biomeTemp = new List<BiomeTempData_V2>();
        foreach(BiomePreset_V2 biome in biomes)
        {
            if(biome.MatchCondition(height, moisture, heat))
            {
                biomeTemp.Add(new BiomeTempData_V2(biome));                
            }
        }

        float curVal = 0.0f;
        
        BiomePreset_V2 biomeToReturn = null;

        foreach(BiomeTempData_V2 biome in biomeTemp)
        {
            if(biomeToReturn == null)
            {
                biomeToReturn = biome.biome;
                curVal = biome.GetDiffValue(height, moisture, heat);
            }
            else
            {
                if(biome.GetDiffValue(height, moisture, heat) < curVal)
                {
                    biomeToReturn = biome.biome;
                    curVal = biome.GetDiffValue(height, moisture, heat);
                }
            }
        }
        if(biomeToReturn == null)
        {
            biomeToReturn = biomes[0];
        }
        return biomeToReturn;
    }

}

public class BiomeTempData_V2
{
    public BiomePreset_V2 biome;
    public BiomeTempData_V2 (BiomePreset_V2 preset)
    {
        biome = preset;
    }
        
    public float GetDiffValue (float height, float moisture, float heat)
    {
        return (height - biome.minHeight) + (moisture - biome.minMoisture) + (heat - biome.minHeat);
    }
}
