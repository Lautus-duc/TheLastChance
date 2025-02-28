using UnityEngine;
public class Drink : Food
{
    public DrinkType DrinkCategory { get; private set; }
    
    public Drink(string name, Sprite icon, DrinkType drinkCategory) 
        : this(name, icon)
    {
        DrinkCategory = drinkCategory;
    }
    
    public Drink(string name, Sprite icon) : base(name, icon) {}
}