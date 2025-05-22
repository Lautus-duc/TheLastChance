using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlotUI : MonoBehaviour,
    IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite icon;
    public TextMeshProUGUI quantityText;
    private InventoryInManager.InventorySlot slot;
    [SerializeField]
    InventoryInManager inventoryManager;

    public void Setup(InventoryInManager.InventorySlot s)
    {
        slot = s;
        icon = s.Item.Icon;
        quantityText.text = $"x{s.Quantity}";
    }

    public void Refresh()
    {
        quantityText.text = $"x{slot.Quantity}";
    }

    public void OnPointerEnter(PointerEventData e)
    {
        inventoryManager.ShowDetail(slot);
    }

    public void OnPointerExit(PointerEventData e)
    {
        inventoryManager.HideDetail();
    }

    public void OnPointerClick(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Left)
            inventoryManager.UseItem(slot);
        else if (e.button == PointerEventData.InputButton.Right)
            inventoryManager.DropItem(slot);
    }
}
