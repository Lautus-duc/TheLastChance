using System.Collections.Generic;
using UnityEngine;
using GeneralEnumList;

public class Vegetation : MonoBehaviour
{
    [SerializeField]
    bool haveWood;
    [SerializeField]
    List<FruitType> listOfFood;

    public (bool,FruitType) IsHit()
    {
        var ret = listOfFood[Random.Range(0, listOfFood.Count)];
        if (haveWood)
        {
            if (Random.Range(0f, 2f) > 0.5f)
            {
                haveWood = false;
                return (true, ret);
            }
        }
        return (false, ret);
    }
}
