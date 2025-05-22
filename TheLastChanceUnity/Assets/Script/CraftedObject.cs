using GeneralEnumList;
using UnityEngine;

public class CraftedObject : InventoryItem
{
    public CraftedObjectType CraftedCategory { get; private set; }

    public CraftedObject(string name, Sprite icon, CraftedObjectType craftedCategory, GameObject worldPrefab) : base(name, icon, ItemType.CraftedObject, worldPrefab)
    {
        CraftedCategory = craftedCategory;
    }
}