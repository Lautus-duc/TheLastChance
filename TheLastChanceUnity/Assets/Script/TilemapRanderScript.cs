using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapRanderScript : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private Tilemap tilemapCol;

    public void SwitchToDay()
    {
        tilemapCol.color = new Color(1f, 1f, 1f, 1f);
        tilemap.color = new Color(1f, 1f, 1f, 1f);
    }
    public void SwitchToNight()
    {
        tilemapCol.color = new Color(1f, 0f, 0f, 1f);
        tilemap.color = new Color(121f / 255f, 59f / 255f, 59f / 255f, 1f);
    }
}
