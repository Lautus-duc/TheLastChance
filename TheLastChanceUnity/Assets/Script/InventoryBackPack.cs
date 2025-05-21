using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

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
        if (wood < 10 || stone < 5) return false;
        wood -= 10;
        stone -= 5;
        AddShovel();
        return true;
    }
    private void AddShovel()
    {
        haveShovel = true;
    }
}
