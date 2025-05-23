using UnityEngine;
using Photon.Pun;

public class PlayerFight : PlayerStats
{
    [SerializeField]
    public PlayerBarre HP_Barre_Script;
    public GameManagerInGame gameManager;
    public int NP;

    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("PlayerGameManager").GetComponent<GameManagerInGame>();
        NP = gameManager.NextNPforPlayer();
        if (NP == 2) // Ceci est la uniquement pour suprimer les doublons créé par Proton
        {
            PhotonNetwork.Destroy(gameObject); 
        }
    }

    public void GetDammages(float degatReceve)
    {
        Health -= degatReceve;
        if (Health <= 0)
        {
            Health = 0;
            HP_Barre_Script.ChangeBarre(0, maxHealth);
            IsKill();
        }
        HP_Barre_Script.ChangeBarre(Health, maxHealth);
    }

    public void IsKill (){
        gameManager.PlayerDeath(gameObject);
    }
    
    public void GetHeal(float healReceve)
    {
        Health += healReceve;
    }
}
