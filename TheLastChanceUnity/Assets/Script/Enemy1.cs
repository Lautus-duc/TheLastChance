using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Collections;

public class Enemy1 : EnemyStat
{
    private Transform EnemyTransform;

    public bool IsNotInCouroutine = true;

    public GameObject targetPlayer;
    public Transform targetTransform;
    private Animator anim;
    public Vector2 dir;

    [SerializeField]
    private float distanceAccessible = 10f;

    [SerializeField]
    private string typeOfTarget = "Player";

    [SerializeField]
    private float speed = 1f;

    private float x1;
    private float y1;
    
    private float x2;
    private float y2;
    

    void Start()
    {
        EnemyTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.freezeRotation = true;
    }

    void Update()
    {
        GameObject[] newtargetsPlayer = GameObject.FindGameObjectsWithTag(typeOfTarget);
        GameObject newtargetPlayer = null;

        foreach (var targetPlayerIN in newtargetsPlayer)
        {
            if (GetDistance(targetPlayerIN.GetComponent<Transform>()))
            {
                newtargetPlayer = targetPlayerIN;
                break;
            }
        }
        if (newtargetPlayer != null)
        {
            Deplacement();
        }
        else if (targetPlayer == null)
        {
            targetPlayer = newtargetPlayer;
            targetTransform = EnemyManager.ThePlayerMostClose(EnemyTransform, typeOfTarget);
        }
        if(targetTransform == null)
        {
            targetPlayer = null;
            Deplacement();
        }
    }


    private bool GetDistance(Transform transform)
    {
        if (transform is null) return false;

        x2 = transform.position.x;
        y2 = transform.position.y;
        x1 = GetComponent<Transform>().position.x;
        y1 = GetComponent<Transform>().position.y;

        return Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) < distanceAccessible*distanceAccessible;
    }


    private void Deplacement()
    {
        if(IsNotInCouroutine)
        {
            if (targetPlayer is null || !GetDistance(targetTransform))
            {
                StartCoroutine(WaitAPlayer());
            }
            else
            {
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
    }


    private IEnumerator WaitAPlayer()
    {
        IsNotInCouroutine = false;
        dir.y = 0;
        dir.x = 1f;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(0.5f);
        dir.x -= 1f;
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        yield return new WaitForSeconds(0.5f);

        IsNotInCouroutine = true;
    }

}
