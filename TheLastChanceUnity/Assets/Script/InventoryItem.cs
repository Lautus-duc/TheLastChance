using UnityEngine;
using GeneralEnumList;
public class InventoryItem
{
    public string Name { get; private set; }
    public Sprite Icon { get; private set; }
    public ItemType Type { get; private set; }
    public GameObject WorldPrefab { get; }

    public InventoryItem(string name, Sprite icon, ItemType type, GameObject worldPrefab = null)
    {
        Name = name; Icon = icon; Type = type;
        WorldPrefab = worldPrefab;
    }
}