using UnityEngine;
using GeneralEnumList;
using TMPro;

public class MaterialSlotUI : MonoBehaviour
{

    [SerializeField]
    InventoryBackPack inventoryBackPack;
    [SerializeField]
    CraftObjectType craftObjectType;

    TextMeshProUGUI textQuantity;

    void Start()
    {
        textQuantity = GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        int ret = 0;
        if (craftObjectType == CraftObjectType.Wood)
        {
            ret = inventoryBackPack.Wood;
        }
        else if (craftObjectType == CraftObjectType.Iron)
        {
            ret = inventoryBackPack.Iron;
        }
        else if (craftObjectType == CraftObjectType.Stone)
        {
            ret = inventoryBackPack.Stone;
        }
        else if (craftObjectType == CraftObjectType.Gold)
        {
            ret = inventoryBackPack.Gold;
        }
        textQuantity.text = $"x{ret}";
    }
}
