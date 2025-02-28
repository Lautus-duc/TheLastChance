namespace DefaultNamespace;

public class Vegetable : Food
{
    public VegetableType VegetableCategory { get; private set; }
    
    public Vegetable(string name, Sprite icon, VegetableType vegetableCategory) 
        : this(name, icon)
    {
        VegetableCategory = vegetableCategory;
    }
    
    public Vegetable(string name, Sprite icon) : base(name, icon) {}
}