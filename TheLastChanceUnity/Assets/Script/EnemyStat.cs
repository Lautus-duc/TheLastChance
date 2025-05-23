using System.Diagnostics.Tracing;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class EnemyStat : MonoBehaviour
{


    public Transform targetTransform;
    public bool IsAlive { get{ return Health>0; } }
    public float Health;
    public float MaxHealth;
    public float Damage;
    public float Speed;
    
    [SerializeField]
    private EnemyManager enemyManager;

    public EnemyManager EnemyManager{get{return enemyManager; } set{enemyManager = value ;} }

    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public bool TakeDamage(float degat)
    {
        Health -= degat;
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
