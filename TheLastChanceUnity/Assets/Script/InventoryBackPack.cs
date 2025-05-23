using System.Collections.Generic;
using System.Linq;
using GeneralEnumList;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBackPack : MonoBehaviour
{
    [Header("In Inventary")]
    [Header("Materails")]
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
    
    [Header("Fruit")]
    [SerializeField]
    public int Apple = 0;
    [SerializeField]
    public int Banana = 0;
    [SerializeField]
    public int Strawberry = 0;
    [SerializeField]
    public int Raspberry = 0;
    [SerializeField]
    public int Cherry = 0;
    [SerializeField]
    public int Avocado = 0;
    [SerializeField]
    public int Wheat = 0;
    [SerializeField]
    public int Lemon = 0;

    [SerializeField]
    Image shovelImage;
    [SerializeField]
    public Sprite nonIcon;
    [SerializeField]
    PlayerAttack playerAttack;

    public void AddFruit(FruitType fruitType)
    {
        AddFruit(fruitType, 1);
    }

    private void AddFruit(FruitType fruitType,int value)
    {
        switch (fruitType)
        {
            case FruitType.Apple:
                Apple += value;
                break;
            case FruitType.Banana:
                Banana += value;
                break;
            case FruitType.Strawberry:
                Strawberry += value;
                break;
            case FruitType.Raspberry:
                Raspberry += value;
                break;
            case FruitType.Cherry:
                Cherry += value;
                break;
            case FruitType.Avocado:
                Avocado += value;
                break;
            case FruitType.Wheat:
                Wheat += value;
                break;
            case FruitType.Lemon:
                Lemon += value;
                break;
            default:
                break;
        }
    }

    public int GetFruit(FruitType fruitType)
    {
        switch (fruitType)
        {
            case FruitType.Apple:
                return Apple;
            case FruitType.Banana:
                return Banana;
            case FruitType.Strawberry:
                return Strawberry;
            case FruitType.Raspberry:
                return Raspberry;
            case FruitType.Cherry:
                return Cherry;
            case FruitType.Avocado:
                return Avocado;
            case FruitType.Wheat:
                return Wheat;
            case FruitType.Lemon:
                return Lemon;
            default:
                return 0;
        }
    }
    

    public bool ConsomFruit(FruitType fruitType)
    {

        if (GetFruit(fruitType) > 0 && playerAttack.Eat(6))
        {
            AddFruit(fruitType,-1);
            return true;
        }
        else return false;
    }
    public bool ConsomFruit()
    {
        if (GetFruit(FruitType.Apple) > 0 && playerAttack.Eat(3))
        {
            AddFruit(FruitType.Apple,-1);
            return true;
        }
        return false;
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
