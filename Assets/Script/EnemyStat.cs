using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{


    public bool IsAlive { get{ return PV>0; } }

    [SerializeField]
    public float PV{get;set;}
    
    [SerializeField]
    public float MaxPV{get;set;}

    public float Damage{get;set;}

    public float Speed{get;set;}
    
    [SerializeField]
    private EnemyManager enemyManager;

    public EnemyManager EnemyManager{get{return enemyManager; } set{enemyManager = value ;} }

    public EnemyStat()
    {
        PV = 250f;
        Damage = 20;
    }


    public void RecevoirDegat(float degat){
        PV -= degat;
        Debug.Log("Ennnnnnnnnn");
        if (!IsAlive)
        {
            enemyManager.ParticleEnemyDeath(GetComponent<Transform>());
            Destroy(gameObject);
        }
    }



}
