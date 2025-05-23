using UnityEngine;
using TMPro;
using GeneralEnumList;
using UnityEngine.UI;

public class OthersSlotUI : MonoBehaviour
{
    [SerializeField]
    public FruitType fruitType;
    Image image;
    [SerializeField]
    public Sprite icon;
    public TextMeshProUGUI quantityText;
    [SerializeField]
    InventoryInManager inventoryManager;
    [SerializeField]
    public InventoryBackPack inventoryBackPack;
    void Start()
    {
        image = GetComponent<Image>();
        quantityText = GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        int ret = inventoryBackPack.GetFruit(fruitType);
        if (ret > 0)
        {
            image.sprite = icon;
            image.color = new Color(1,1,1,1);
        }
        quantityText.text = $"x{ret}";
    }
    public void Consom()
    {
        inventoryBackPack.ConsomFruit(fruitType);
    }
}
