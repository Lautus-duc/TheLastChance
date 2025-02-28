namespace DefaultNamespace;

public class PlayerInteraction : MonoBehaviour
{
    public PaletteManager paletteManager;
    
    private void OnTriggerEnter(Collider other)
    {
        InventoryItem item = other.GetComponent<ItemPickup>()?.GetItem();
        if (item != null)
        {
            paletteManager.AddItem(item);
            Destroy(other.gameObject);
        }
    }
}