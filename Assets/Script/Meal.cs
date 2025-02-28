using UnityEngine;

public class Meal : Food
{
    public MealType MealCategory { get; private set; }
    
    public Meal(string name, Sprite icon, MealType mealCategory) 
        : this(name, icon)
    {
        MealCategory = mealCategory;
    }
    
    public Meal(string name, Sprite icon) : base(name, icon) {}
}