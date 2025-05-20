using UnityEngine;
using Photon.Pun;

public class PlayerFight : PlayerStats
{
    [SerializeField]
    public PlayerHealthBarre HP_Barre_Script;
    public GameManagerInGame gameManager;
    public int NP;

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("PlayerGameManager").GetComponent<GameManagerInGame>();
        NP = gameManager.NextNPforPlayer();
        if (NP == 2)
        {
            PhotonNetwork.Destroy(gameObject); 
        }
    }

    public void GetDammages(float degatReceve)
    {
        PV -= degatReceve;
        if (PV <= 0)
        {
            PV = 0;
            HP_Barre_Script.ChangeBarrePV(0, maxPV);
            IsKill();
        }
        HP_Barre_Script.ChangeBarrePV(PV, maxPV);
    }

    public void IsKill (){
        gameManager.PlayerDeath(gameObject);
    }
    
    public void GetHeal(float healReceve)
    {
        PV += healReceve;
    }
}
