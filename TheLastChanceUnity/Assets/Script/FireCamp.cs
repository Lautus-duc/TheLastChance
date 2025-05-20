using UnityEngine;

public class FireCamp : MonoBehaviour
{
    private GameManagerInGame gameManager;
    public bool Check_Inventairy()
    {
        int woodCheck = 200;
        int stoneCheck = 130;
        int goldCheck = 50;
        int ironCheck = 30;
        foreach (var player in gameManager.PlayerList)
        {
            
        }
        return woodCheck <= 0 && stoneCheck <= 0 && goldCheck <= 0 && ironCheck <= 0;
    }
}
