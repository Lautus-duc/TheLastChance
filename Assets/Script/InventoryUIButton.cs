using UnityEngine;
using UnityEngine.UI;

public class InventoryUIButton : MonoBehaviour
{
    private InventoryItem item;
    private InventoryUIManager inventoryUI;

    public Image itemIcon;
    public Text itemName;

    public void Setup(InventoryItem newItem, InventoryUIManager uiManager)
    {
        item = newItem;
        inventoryUI = uiManager;

        itemIcon.sprite = item.Icon;
        itemName.text = item.Name;
        
        GetComponent<Button>().onClick.AddListener(() => inventoryUI.DisplayItem(item));
    }
}