using UnityEngine;

public class Defence : InventoryItem
{
    public Defence(string name, Sprite icon) : this(name, icon, ItemType.Defence) {}
    
    public Defence(string name, Sprite icon, ItemType type) : base(name, icon, type) {}
}