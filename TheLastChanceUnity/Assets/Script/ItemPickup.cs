using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private InventoryItem item;  
    [SerializeField]
    InventoryInManager inventoryManager;
    
    public InventoryItem GetItem()
    {
        return item;
    }

    public string GetItemName()
    {
        return item.Name;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            InventoryItem picked = GetItem();
            Debug.Log($"Picked up: {picked.Name}");
            
            inventoryManager.AddItem(picked);
            Destroy(gameObject);
        }
    }
    
    public static void CreateDrop(InventoryItem item, Vector3 worldPosition)
    {
        if (!item.WorldPrefab)
        {
            return;
        }
        
        GameObject go = Instantiate(item.WorldPrefab, worldPosition, Quaternion.identity);
        
        var pickup = go.AddComponent<ItemPickup>();
        pickup.item = item;
    }
}