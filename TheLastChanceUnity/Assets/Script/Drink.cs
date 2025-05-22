using UnityEngine;
using GeneralEnumList;

public class Drink : Food
{
    public DrinkType DrinkCategory { get; private set; }

    public Drink(string name, Sprite icon, DrinkType drinkCategory, int healValue, GameObject worldPrefab = null)
        : base(name, icon, FoodType.Drinks, healValue, worldPrefab)
    {
        DrinkCategory = drinkCategory;
    }
}