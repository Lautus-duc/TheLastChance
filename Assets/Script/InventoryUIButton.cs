using UnityEngine;
using UnityEngine.UI;

public class InventoryUIButton : MonoBehaviour
{
    private InventoryItem item;
    private InventoryUIManager inventoryUI;

    public void Setup(InventoryItem newItem, InventoryUIManager uiManager)
    {
        item = newItem;
        inventoryUI = uiManager;
        GetComponent<Image>().sprite = item.Icon;
        GetComponent<Button>().onClick.AddListener(() => inventoryUI.DisplayItem(item));
    }
}