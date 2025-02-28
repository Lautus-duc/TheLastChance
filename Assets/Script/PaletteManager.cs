namespace DefaultNamespace;

public class PaletteManager : MonoBehaviour
{
    public Transform inventoryPanel;
    public GameObject inventoryItemPrefab;
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        inventoryItems.Add(item);
        GameObject newItem = Instantiate(inventoryItemPrefab, inventoryPanel);
        newItem.GetComponent<Image>().sprite = item.Icon;
        newItem.GetComponent<Button>().onClick.AddListener(() => DisplayItem(item));
    }

    private void DisplayItem(InventoryItem item)
    {
        Debug.Log("Displaying item: " + item.Name);
        // Implement logic to show the item in the game world
    }
}