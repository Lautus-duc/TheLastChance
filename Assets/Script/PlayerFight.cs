using UnityEngine;

public class PlayerFight : PlayerStats
{
    [SerializeField]
    public PlayerHealthBarre HP_Barre_Script;

    public void GetDammages(float degatReceve)
    {
        PV -= degatReceve;
        if (PV<=0){
            PV = 0;
            HP_Barre_Script.ChangeBarrePV(0,maxPV);
            IsKill();
        }
        HP_Barre_Script.ChangeBarrePV(PV,maxPV);
    }

    public void IsKill (){
        gameManager.PlayerDeath();
    }
    
    public void GetHeal(float healReceve)
    {
        PV += healReceve;
    }
}
