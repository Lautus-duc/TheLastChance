using UnityEngine;
using TMPro;
using GeneralEnumList;
using UnityEngine.UI;

public class OthersSlotU : MonoBehaviour
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
    InventoryBackPack inventoryBackPack;
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
            Debug.Log("oui" + icon.name + "  :  " + fruitType);
            image.sprite = icon;
            image.color = new Color(1,1,1,1);
        }
        else
        {
            Debug.Log("non" + icon.name);
            icon = inventoryBackPack.nonIcon;
            image.color = new Color(196f/255f,196f/255f,196f/255f,12f/255f);
        }
        quantityText.text = $"x{ret}";
    }

    public void Consom()
    {
        Debug.Log("It's " + fruitType);
        inventoryBackPack.ConsomFruit(fruitType);
    }
}
