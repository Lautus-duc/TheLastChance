using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using NUnit.Framework.Constraints;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    Rigidbody2D rb;
    Vector2 dir;
    Animator anim;

    void Start()
    {
        anim =GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Mouvement du Hero
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        SetParam();

    }

    void SetParam()
    {
        if(dir.x == 0 && dir.y == 0)
        {
            anim.SetInteger("direction",0);
        }

        else if(dir.y < 0) //bas
        {
            anim.SetInteger("direction",1);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        else if(dir.x > 0) //droite
        {
            anim.SetInteger("direction",2);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        else if(dir.x < 0) //gauche
        {
            anim.SetInteger("direction",2);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        else if(dir.y > 0) //haut
        {
            anim.SetInteger("direction",3);
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }







}
