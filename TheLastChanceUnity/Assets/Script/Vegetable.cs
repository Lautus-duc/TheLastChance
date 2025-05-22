using UnityEngine;
using GeneralEnumList;

public class Vegetable : Food
{
    public VegetableType VegetableCategory { get; private set; }

    public Vegetable(string name, Sprite icon, VegetableType vegetableCategory, int healValue, GameObject worldPrefab = null)
        : base(name, icon, FoodType.Vegetables, healValue, worldPrefab)
    {
        VegetableCategory = vegetableCategory;
    }
}