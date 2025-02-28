namespace DefaultNamespace;

public class CraftObject : InventoryItem
{
    public CraftObject(string name, Sprite icon) : this(name, icon, ItemType.CraftObject) {}
    
    public CraftObject(string name, Sprite icon, ItemType type) : base(name, icon, type) {}
}