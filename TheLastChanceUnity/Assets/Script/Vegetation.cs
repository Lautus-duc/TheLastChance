using System.Collections.Generic;
using UnityEngine;

public class Vegetation : MonoBehaviour
{
    [SerializeField]
    List<ItemType> itemTypesList;
    [SerializeField]
    bool haveWood;

    public bool IsHit()
    {
        if (haveWood) {
            if (Random.Range(0f, 2f) > 1)
            {
                haveWood = false;
                return true;
            }
        }
        return false;
    }
}
