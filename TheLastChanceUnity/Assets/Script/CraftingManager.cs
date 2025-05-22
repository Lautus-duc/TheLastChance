using System.Collections.Generic;
using System.Linq;
using GeneralEnumList;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [System.Serializable]
    public struct Recipe
    {
        public List<CraftObjectType> ingredients;
        public CraftedObjectType    result;
        public GameObject           resultPrefab;
        public Sprite               resultIcon;
    }
    [SerializeField]
    InventoryInManager inventoryManager;

    public List<Recipe> recipes;

    public bool CanCraft(Recipe r) =>
        r.ingredients.All(i => inventoryManager.Has(i));

    public void Craft(Recipe r)
    {
        if (!CanCraft(r)) return;

        foreach (var ing in r.ingredients)
            inventoryManager.Remove(ing);

        var newItem = new CraftedObject(
            r.result.ToString(),
            r.resultIcon,
            r.result,
            r.resultPrefab
        );
        inventoryManager.AddItem(newItem);
    }
}
