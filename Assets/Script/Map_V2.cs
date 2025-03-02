using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;


public class Map_V2 : MonoBehaviour
{
    [Header("Biomes")]
    public BiomePreset_V2[] biomes;
    public BiomePreset_V2 baseBiome;
    public BiomePreset_V2 firstBiome;

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
    [Header("Vegetal Map")]
    public Wave[] vegetalWaves;
    public float[,] vegetalMap;

    [Header("Base")]
    public GameObject campFire;
    public GameObject kitchen;
    public GameObject crafter;

    [Header("Autres")]
    public GameObject tilePrefab;
    public TileMapGenerate_V2 tileMapGenerate;




    

    void GenerateMap ()
    {
        // height map
        heightMap = NoiseGenerator.Generate(width, height, scale, heightWaves, offset);
        // moisture map
        moistureMap = NoiseGenerator.Generate(width, height, scale, moistureWaves, offset);
        // heat map
        heatMap = NoiseGenerator.Generate(width, height, scale, heatWaves, offset);
        // vegetal map
        vegetalMap = NoiseGenerator.Generate(width, height, scale, vegetalWaves, offset);
        
        int maxDist = (width*width + height*height)/4;

        for(int x = 0; x < width; ++x)
        {
            for(int y = 0; y < height; ++y)
            {
                int ymin=height/2-y;
                if(y>height/2){
                    ymin*=-1;
                }
                int xmin=width/2-x;
                if(x>width/2){
                    xmin*=-1;
                }
                if(xmin*xmin+ymin*ymin<81){
                    BiomePreset_V2 bpv = baseBiome; 
                    Tile newTile = bpv.GetTileSprite();
                    tileMapGenerate.SetMap(newTile,x-(height/2),y-(height/2),false);
                }
                else if(xmin*xmin+ymin*ymin<600){
                    BiomePreset_V2 bpv = firstBiome; 
                    Tile newTile = bpv.GetTileSprite();
                    tileMapGenerate.SetMap(newTile,x-(height/2),y-(height/2),false);

                    int vegNumber = bpv.IsVegetalise(vegetalMap[x,y]);

                    if(vegNumber!=-1){
                        Transform vegPrefab = bpv.GetVegetalGO().GetComponent<Transform>();
                        Transform VegInstanciate = Instantiate(vegPrefab, new Vector3((x-(width/2))*1.155f+4.4f, (y-(height/2))*1.16f+5f, 0), Quaternion.identity);
                        VegInstanciate.GetComponent<SpriteRenderer>().sortingOrder = -(int)Math.Floor(VegInstanciate.GetComponent<Transform>().position.y);
                        if(UnityEngine.Random.Range(0, 3)<=1){
                            VegInstanciate.GetComponent<SpriteRenderer>().flipX = true;
                        }
                    }
                }
                else{
                    //-----Using the TileMapGenerate-----//
                    (BiomePreset_V2 biomeP,bool isCol) = GetBiome(heightMap[x, y], moistureMap[x, y], heatMap[x, y]);
                    Tile newTile = biomeP.GetTileSprite();
                    tileMapGenerate.SetMap(newTile,x-(height/2),y-(height/2),isCol);

                    int vegNumber = biomeP.IsVegetalise(vegetalMap[x,y]);

                    if(vegNumber!=-1){
                        Transform vegPrefab = biomeP.GetVegetalGO().GetComponent<Transform>();
                        Transform VegInstanciate = Instantiate(vegPrefab, new Vector3((x-(width/2))*1.155f+4.4f, (y-(height/2))*1.16f+5f, 0), Quaternion.identity);
                        VegInstanciate.GetComponent<SpriteRenderer>().sortingOrder = -(int)Math.Floor(VegInstanciate.GetComponent<Transform>().position.y);
                        if(UnityEngine.Random.Range(0, 3)<=1){
                            VegInstanciate.GetComponent<SpriteRenderer>().flipX = true;
                        }
                    }
                }
            }
        }
        tileMapGenerate.tilemap.RefreshAllTiles();
        Transform FCInstanciate = Instantiate(campFire.GetComponent<Transform>(), new Vector3(0f, 0, 0), Quaternion.identity);
        FCInstanciate.GetComponent<SpriteRenderer>().sortingOrder = -(int)Math.Floor(FCInstanciate.GetComponent<Transform>().position.y);
        Transform KitchenInstanciate = Instantiate(kitchen.GetComponent<Transform>(), new Vector3(5f, 2, 0), Quaternion.identity);
        KitchenInstanciate.GetComponent<SpriteRenderer>().sortingOrder = -(int)Math.Floor(KitchenInstanciate.GetComponent<Transform>().position.y);
        Transform CrafterInstanciate = Instantiate(crafter.GetComponent<Transform>(), new Vector3(3f, 6f, 0), Quaternion.identity);
        CrafterInstanciate.GetComponent<SpriteRenderer>().sortingOrder = -(int)Math.Floor(CrafterInstanciate.GetComponent<Transform>().position.y);
    }

    void Start ()
    {
        tileMapGenerate = GetComponent<TileMapGenerate_V2>();
        TilemapRenderer TRendOfTileMap = GetComponent<TilemapRenderer>();
        TRendOfTileMap.sortingOrder = -height*2;
        GenerateMap();
    }

    (BiomePreset_V2,bool) GetBiome (float height, float moisture, float heat)
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

        bool isColider = biomeToReturn.IsCollidered;
        return (biomeToReturn,isColider);
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
