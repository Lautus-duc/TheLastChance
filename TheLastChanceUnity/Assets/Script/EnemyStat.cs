using System.Diagnostics.Tracing;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
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

    protected Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public EnemyStat()
    {
        PV = 250f;
        Damage = 20;
    }


    public bool RecevoirDegat(float degat)
    {
        PV -= degat;
        if (!IsAlive)
        {
            enemyManager.ParticleEnemyDeath(GetComponent<Transform>());
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    void Update()
    {
        spriteRenderer.sortingOrder=-(int)Math.Floor(rb.position.y);
    }



}
