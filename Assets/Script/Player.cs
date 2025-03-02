using System;
using UnityEngine;

public class Player : PlayerStats
{

    public event Action MonEvent;

    public bool IsDead{ get{return PV<=0f; } }


    void Update()
    {
        if (MonEvent != null && IsDead)
        {
            MonEvent();
        }
    }


    public void ReceveDegat(float degatReceve)
    {
    }


    public void Attack(EnemyFight ennemi)
    {
        ennemi.RecevoirDegat(Damage);
    }







}
