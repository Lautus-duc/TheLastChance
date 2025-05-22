using GeneralEnumList;
using UnityEngine;

public class CraftObject : InventoryItem
{
    public CraftObjectType CraftCategory { get; private set; }

    public CraftObject(string name, Sprite icon, CraftObjectType craftCategory, GameObject worldPrefab) : base(name, icon, ItemType.CraftObject, worldPrefab)
    {
        CraftCategory = craftCategory;
    }
}