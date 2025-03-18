using UnityEngine;
public class PoisonedFood : Food
{
    public PoisonedFood(string name, Sprite icon) : base(name, icon)
    {
        Debug.Log("Warning!");
    }
}