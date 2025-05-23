using System.Collections.Generic;
using System.Linq;
using GeneralEnumList;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBackPack : MonoBehaviour
{
    [Header("In Inventary")]
    [SerializeField]
    int wood;
    [SerializeField]
    int stone;
    [SerializeField]
    int iron;
    [SerializeField]
    int gold;
    [SerializeField]
    bool haveShovel = false;
    [SerializeField]
    public Dictionary<FruitType, int> listOfFruit = new Dictionary<FruitType, int>();
    [SerializeField]
    Image shovelImage;

    public void AddFruit(FruitType fruitType)
    {
        if (!listOfFruit.ContainsKey(fruitType)) listOfFruit[fruitType] = 1;
        else listOfFruit[fruitType] += 1;
    }

    public bool ConsomFruit(FruitType fruitType)
    {
        if (listOfFruit.ContainsKey(fruitType) && listOfFruit[fruitType] > 0)
        {
            listOfFruit[fruitType] -= 1;
            if (listOfFruit[fruitType] == 0) listOfFruit.Remove(fruitType);
            return true;
        }
        else return false;
    }
    public bool ConsomFruit()
    {
        if (listOfFruit.Count>0)
        {
            ConsomFruit(listOfFruit.First(x=>x.Value>0).Key);
            return true;
        }
        else return false;
    }

    public int Wood
    {
        get { return wood; }
        set { wood = value; }
    }
    public int Stone
    {
        get { return stone; }
        set { stone = value; }
    }
    public int Iron
    {
        get { return iron; }
        set { iron = value; }
    }
    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }
    public bool HaveShovel
    {
        get => haveShovel;
    }
    public bool CreateAShovel()
    {
        if (haveShovel || wood < 10 || stone < 5) return false;
        wood -= 10;
        stone -= 5;
        AddShovel();
        return true;
    }
    private void AddShovel()
    {
        haveShovel = true;
        shovelImage.enabled = true;
    }
}
