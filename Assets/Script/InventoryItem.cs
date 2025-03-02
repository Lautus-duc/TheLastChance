using UnityEngine;
public class InventoryItem
{
    public string Name { get; private set; }
    public Sprite Icon { get; private set; }
    public ItemType Type { get; private set; }

    public InventoryItem(string name, Sprite icon, ItemType type)
    {
        Name = name;
        Icon = icon;
        Type = type;
    }
}