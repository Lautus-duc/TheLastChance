using System;
using System.Collections;
using Unity;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float seed;
    public float frequency;
    public float amplitude;

}

public class NoiseGenerator
{
    public static float[,] Generate (int width, int height, float scale, Wave[] waves, Vector2 offset, float _seed)
    {
        float[,] noiseMap = new float[width, height];
        for(int x = 0; x < width; ++x)
        {
            for(int y = 0; y < height; ++y)
            {
                float samplePosX = (float)x * scale + offset.x;
                float samplePosY = (float)y * scale + offset.y;
                float normalization = 0.0f;
                
                foreach(Wave wave in waves)
                {
                    wave.seed = _seed;
                    noiseMap[x, y] += wave.amplitude * Mathf.PerlinNoise(samplePosX * wave.frequency + wave.seed, samplePosY * wave.frequency + wave.seed);
                    normalization += wave.amplitude;
                }
                
                noiseMap[x, y] /= normalization;
            }
        }
            
        return noiseMap;
    }
}


