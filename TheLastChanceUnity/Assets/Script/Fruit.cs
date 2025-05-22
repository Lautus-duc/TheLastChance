using UnityEngine;
using GeneralEnumList;

public class Fruit : Food
{
    public FruitType FruitCategory { get; private set; }

    public Fruit(string name, Sprite icon, FruitType fruitCategory, int healValue, GameObject worldPrefab = null)
        : base(name, icon, FoodType.Fruits, healValue, worldPrefab)
    {
        FruitCategory = fruitCategory;
    }
}