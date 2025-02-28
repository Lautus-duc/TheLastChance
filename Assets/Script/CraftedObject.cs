using UnityEngine;

public class CraftedObject : InventoryItem
{
    public CraftedObject(string name, Sprite icon) : this(name, icon, ItemType.CraftedObject) {}
    
    public CraftedObject(string name, Sprite icon, ItemType type) : base(name, icon, type) {}
}