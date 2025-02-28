using UnityEngine;

public class Food : InventoryItem
{
    public FoodType FoodCategory { get; private set; }
    
    public Food(string name, Sprite icon, FoodType foodCategory) 
        : this(name, icon)
    {
        FoodCategory = foodCategory;
    }
    
    public Food(string name, Sprite icon) : base(name, icon, ItemType.Food) {}
}