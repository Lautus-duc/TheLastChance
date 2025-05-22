using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using GeneralEnumList;
using UnityEngine.UI;

public class InventoryInManager : MonoBehaviour
{

    [Header("UI References")]
    [Tooltip("Prefab for each inventory slot (Button/Image/Text)")]
    public GameObject slotPrefab;
    [Tooltip("Parent transform containing slot grid layout")]
    public Transform slotsParent;
    [Tooltip("Image component for displaying details when hovering a slot")]
    public Image detailImage;
    [Tooltip("Text component for displaying name and quantity details")]
    public Text detailText;

    private List<InventorySlot> _slots = new List<InventorySlot>();
    [SerializeField]
    PlayerBarre playerBarre;
    [SerializeField]
    PlayerStats playerStats;
    [SerializeField]
    PlayerMouvement playerMouvement;
    
    public void AddItem(InventoryItem newItem)
    {
        var slot = _slots.FirstOrDefault(s => s.Item.Name == newItem.Name);
        if (slot != null)
        {
            slot.Quantity++;
            slot.UI.Refresh();
        }
        else
        {
            slot = new InventorySlot(newItem);
            _slots.Add(slot);
            CreateSlotUI(slot);
        }
    }

    private void CreateSlotUI(InventorySlot slot)
    {
        var go = Instantiate(slotPrefab, slotsParent);
        var ui = go.GetComponent<InventorySlotUI>();
        ui.Setup(slot);
        slot.UI = ui;
    }
    
    public void UseItem(InventorySlot slot)
    {
        switch (slot.Item.Type)
        {
            case ItemType.Food:
                if (slot.Item is Food food)
                    playerBarre.ChangeBarre(food.HealValue, playerBarre.HeightBarre);
                break;

           // case ItemType.Defence:
              //  if (slot.Item is Defence def)
                   // PlayerStats.Instance.AddDefence(def.DefenceValue);
              //  break;

                // case ItemType.CraftedObject:
             //   if (slot.Item is CraftedObject crafted)
              //  {
                    // **Install that spaceship part**:
                //    SpaceShipManager.Instance.InstallPart(crafted.CraftedCategory);
               // }
              //  break;

            default:
                Debug.LogWarning("UseItem: unsupported item type " + slot.Item.Type);
                break;
        }

        DecrementSlot(slot);
    }

    private void DecrementSlot(InventorySlot slot)
    {
        slot.Quantity--;
        if (slot.Quantity <= 0)
            RemoveSlot(slot);
        else
            slot.UI.Refresh();
    }

    private void RemoveSlot(InventorySlot slot)
    {
        _slots.Remove(slot);
        Destroy(slot.UI.gameObject);
    }

    public void DropItem(InventorySlot slot)
    {
        if (slot.Item.WorldPrefab != null)
        {
            Vector3 spawnPos = playerMouvement.transform.position + Vector3.forward;
            Instantiate(slot.Item.WorldPrefab, spawnPos, Quaternion.identity);
        }
        DecrementSlot(slot);
    }

    public void ShowDetail(InventorySlot slot)
    {
        detailImage.sprite = slot.Item.Icon;
        detailText.text = $"{slot.Item.Name} x{slot.Quantity}";
    }

    public void HideDetail()
    {
        detailImage.sprite = null;
        detailText.text = string.Empty;
    }

    public bool Has(CraftObjectType type)
    {
        return _slots.Any(s => s.Item is CraftObject co && co.CraftCategory == type && s.Quantity > 0);
    }

    public void Remove(CraftObjectType type)
    {
        var slot = _slots.FirstOrDefault(s => s.Item is CraftObject co && co.CraftCategory == type);
        if (slot != null)
            DecrementSlot(slot);
    }
    
    public class InventorySlot
    {
        public InventoryItem Item;
        public int Quantity;
        public InventorySlotUI UI;

        public InventorySlot(InventoryItem item)
        {
            Item = item;
            Quantity = 1;
        }
    }
}
