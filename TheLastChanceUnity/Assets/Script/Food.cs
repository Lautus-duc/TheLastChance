using UnityEngine;
using GeneralEnumList;

public class Food : InventoryItem
{
    public FoodType FoodCategory { get; private set; }
    public int HealValue { get; private set; }

    public Food(string name, Sprite icon, FoodType foodCategory, int healValue, GameObject worldPrefab = null)
        : base(name, icon, ItemType.Food, worldPrefab)
    {
        FoodCategory = foodCategory;
        HealValue = healValue;
    }
}