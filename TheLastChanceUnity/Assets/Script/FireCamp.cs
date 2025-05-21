using System.Linq;
using UnityEngine;

public class FireCamp : MonoBehaviour
{
    private GameManagerInGame gameManager;
    [SerializeField]
    private Transform Rocket1Instanciate;
    [SerializeField]
    private GameObject Rocket;
    [SerializeField]
    private Sprite Rocket2;
    [SerializeField]
    private Sprite Rocket3;

    [SerializeField]
    private float embers = 500;

    private int Part = 1;

    int[][] checkers;

    void Start()
    {
        checkers = new int[3][];
        checkers[0] = new int[]{50,20,0,1,0,1};
        checkers[1] = new int[]{50,15,4,1,1,2};
        checkers[2] = new int[]{50,0,10,1,1,3};
    }

    public bool Check_Inventairy()
    {
        int nbOfPlayer = GameObject.FindGameObjectsWithTag("Player").Count();
        int woodCheck = checkers[Part][0] * nbOfPlayer;
        int stoneCheck = checkers[Part][1] * nbOfPlayer;
        int goldCheck = checkers[Part][2] * nbOfPlayer;
        int ironCheck = checkers[Part][3] * nbOfPlayer;
        bool shovelCheck = checkers[Part][4] == 0;
        int electronicalCheck = checkers[Part][5];
        foreach (var player in GameObject.FindGameObjectsWithTag("Player"))
        {
            var t = player.GetComponent<InventoryBackPack>();
            woodCheck -= t.Wood;
            stoneCheck -= t.Stone;
            goldCheck -= t.Gold;
            ironCheck -= t.Iron;
            shovelCheck = shovelCheck || t.HaveShovel;
        }
        if (woodCheck <= 0 && stoneCheck <= 0 && goldCheck <= 0 && ironCheck <= 0 && 3-gameManager.numberOfObjectives>=electronicalCheck)
        {
            woodCheck = checkers[Part][0] * nbOfPlayer;
            stoneCheck = checkers[Part][1] * nbOfPlayer;
            goldCheck = checkers[Part][2] * nbOfPlayer;
            ironCheck = checkers[Part][3] * nbOfPlayer;
            foreach (var player in GameObject.FindGameObjectsWithTag("Player"))
            {
                var inventoryBackPack = player.GetComponent<InventoryBackPack>();
                //Wood
                if (inventoryBackPack.Wood < woodCheck)
                {
                    woodCheck -= inventoryBackPack.Wood;
                    inventoryBackPack.Wood = 0;
                }
                else
                {
                    inventoryBackPack.Wood -= woodCheck;
                    woodCheck = 0;
                }
                //Stone
                if (inventoryBackPack.Stone < stoneCheck)
                {
                    stoneCheck -= inventoryBackPack.Stone;
                    inventoryBackPack.Stone = 0;
                }
                else
                {
                    inventoryBackPack.Stone -= stoneCheck;
                    stoneCheck = 0;
                }
                //Gold
                if (inventoryBackPack.Gold < goldCheck)
                {
                    goldCheck -= inventoryBackPack.Gold;
                    inventoryBackPack.Gold = 0;
                }
                else
                {
                    inventoryBackPack.Gold -= goldCheck;
                    goldCheck = 0;
                }
                //Iron
                if (inventoryBackPack.Iron < ironCheck)
                {
                    ironCheck -= inventoryBackPack.Iron;
                    inventoryBackPack.Iron = 0;
                }
                else
                {
                    inventoryBackPack.Iron -= ironCheck;
                    ironCheck = 0;
                }
            }
            if (Part == 0)
            {
                Rocket = Instantiate(Rocket1Instanciate,new Vector3(0,4),Quaternion.identity).gameObject;
            }
            else if (Part == 1)
            {
                Rocket.GetComponent<SpriteRenderer>().sprite = Rocket2;
            }
            else
            {
                Rocket.GetComponent<SpriteRenderer>().sprite = Rocket3;
            }
            Part += 1;
            return true;
        }
        return false;
    }

    public void TakeDamage(float damage)
    {
        embers -= damage;
        if (embers <= 0)
        {
            gameManager.GameOver();
        }
    }

}
