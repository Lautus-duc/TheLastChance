using UnityEngine;
using GeneralEnumList;

public class Defence : InventoryItem
{
    public int DefenceValue { get; private set; }

    public Defence(string name, Sprite icon, int defenceValue, GameObject worldPrefab = null)
        : base(name, icon, ItemType.Defence, worldPrefab)
    {
        DefenceValue = defenceValue;
    }
}