namespace DefaultNamespace;

public class ItemPickup : MonoBehaviour
{
    public InventoryItem item;
    
    public InventoryItem GetItem()
    {
        return item;
    }
}