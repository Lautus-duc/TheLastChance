using UnityEngine;
using GeneralEnumList;

public class PoisonedFood : Food
{
    public PoisonedFood(string name, Sprite icon, int healValue, GameObject worldPrefab = null)
        : base(name, icon, FoodType.Poisoned, healValue, worldPrefab)
    {
        Debug.Log("Warning: Poisoned food created!");
    }
}