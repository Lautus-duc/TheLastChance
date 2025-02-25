using UnityEngine;

[CreateAssetMenu(fileName = "BiomePreset", menuName = "New_BiomePreset")]
public class BiomePreset : ScriptableObject
{
    public Sprite[] tiles;
    public float minHeight;
    public float minMoisture;
    public float minHeat;

    public Sprite GetTleSprite ()
    {
        return tiles[Random.Range(0, tiles.Length)];
    }

    public bool MatchCondition (float height, float moisture, float heat)
    {
        return height >= minHeight && moisture >= minMoisture && heat >= minHeat;
    }
}
