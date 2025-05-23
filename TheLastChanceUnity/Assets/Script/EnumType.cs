namespace GeneralEnumList
{
    public enum CraftedObjectType
    {
        Shovel,
        Axe
    }

    public enum CraftObjectType
    {
        Wood,
        Iron,
        Gold,
        Stone
    }

    public enum DefenceType
    {
        Weapon
    }

    public enum DrinkType
    {
        Water
    }

    public enum FoodType
    {
        Drinks,
        Vegetables,
        Fruits,
        Poisoned,
        Meals
    }

    public enum FruitType
    {
        Apple,
        Banana,
        Strawberry,
        Raspberry,
        Cherry,
        Avocado,
        Wheat,
        Lemon
    }

    public class InventorySlot
    {
        public InventoryItem Item;
        public int Quantity;

        public InventorySlot(InventoryItem item)
        {
            Item = item;
            Quantity = 1;
        }
    }

    public enum ItemType
    {
        Food,
        Defence,
        CraftObject,
        CraftedObject
    }

    public enum MealType
    {
        MealeniousWithForestMushrooms,
        MealeniousWithForestMushroomsPoisonous
    }

    public enum PoisonedFoodType
    {
        MealeniousWithForestMushroomsPoisonous
    }
    
    public enum VegetableType
    {
        Cucumber,
        Potato,
        Carrot,
        Salad,
        Tomato,
        Corn,
        Mushroom,
        MushroomPoisonous
    }
}
