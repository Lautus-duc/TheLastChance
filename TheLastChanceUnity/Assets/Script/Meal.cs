using UnityEngine;
using GeneralEnumList;

public class Meal : Food
{
    public MealType MealCategory { get; private set; }

    public Meal(string name, Sprite icon, MealType mealCategory, int healValue, GameObject worldPrefab = null)
        : base(name, icon, FoodType.Meals, healValue, worldPrefab)
    {
        MealCategory = mealCategory;
    }
}