using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public Transform inventoryPanel;
    public GameObject inventoryItemPrefab;
    public GameObject itemDisplayPanel;
    public Image selectedItemImage;
    public Text selectedItemName;

    private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        inventoryItems.Add(item);
        GameObject newItem = Instantiate(inventoryItemPrefab, inventoryPanel);
        newItem.GetComponent<Image>().sprite = item.Icon;

        Button itemButton = newItem.GetComponent<Button>();
        itemButton.onClick.AddListener(() => DisplayItem(item));
    }

    private void DisplayItem(InventoryItem item)
    {
        Debug.Log("Displaying item: " + item.Name);

        if (itemDisplayPanel != null)
        {
            itemDisplayPanel.SetActive(true);
            selectedItemImage.sprite = item.Icon;
            selectedItemName.text = item.Name;
        }
    }

    public void CloseDisplayPanel()
    {
        itemDisplayPanel.SetActive(false);
    }
}