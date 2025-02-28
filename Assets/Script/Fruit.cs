namespace DefaultNamespace;

public class Fruit : Food
{
    public FruitType FruitCategory { get; private set; }
    
    public Fruit(string name, Sprite icon, FruitType fruitCategory) 
        : this(name, icon)
    {
        FruitCategory = fruitCategory;
    }
    
    public Fruit(string name, Sprite icon) : base(name, icon) {}
}