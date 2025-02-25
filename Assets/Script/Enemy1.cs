using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections;

public class Enemy1 : EnemyStat
{

    public GameObject targetPlayer;
    public Transform targetTransform;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 dir;

    [SerializeField]
    private float distanceAccessible = 10f;

    [SerializeField]
    private float speed = 1f;

    private float x1;
    private float y1;
    
    private float x2;
    private float y2;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.freezeRotation = true;
    }

    Enemy1() : base()
    {
        
    }

    void Update()
    {
        GameObject newtargetPlayer = GameObject.FindWithTag("Player");
        if(targetPlayer == null && newtargetPlayer != null)
        {
            targetPlayer = newtargetPlayer;
            targetTransform = targetPlayer.GetComponent<Transform>();
        }

        else if (newtargetPlayer != null && GetDistance() )
        {
            x2 = targetTransform.position.x;
            y2 = targetTransform.position.y;
            Deplacement();
        }
        else
        {
            targetPlayer = null;
            targetTransform = null;
            dir.x = 0;
            dir.y = 0;
        }
    }


    private bool GetDistance()
    {
        x1 = GetComponent<Transform>().position.x;
        y1 = GetComponent<Transform>().position.y;

        return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)) < distanceAccessible;
    }


    private void Deplacement()
    {
        if (targetPlayer is null){
            StartCoroutine(WaitAPlayer());
        }
        else{
            if(x1 < x2)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                dir.x = 1;
            }
            else if(x2<x1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                dir.x = -1;
            }
            else
            {
                dir.x = 0;
            }

            if(y1 < y2)
            {
                dir.y = 1;
            }
            else if (y2 < y1)
            {
                dir.y = -1;
            }
            else
            {
                dir.y = 0;
            }
            rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        }
    }


    private IEnumerator WaitAPlayer()
    {
        dir.y = 0;
        dir.x = 1;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(1f);
        dir.y = 1;
        dir.x = 0;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(1f);
        dir.y = 0;
        dir.x = -1;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(1f);
        dir.y = -1;
        dir.x = 0;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(1f);
    }

}
