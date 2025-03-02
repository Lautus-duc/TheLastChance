using UnityEngine;
using System;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    GameObject InventaryGO;
    Vector2 dir;
    Animator anim;
    SpriteRenderer spriteRenderer;
    private bool isHere;


    void Start()
    {
        anim =GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isHere = true;
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
        {
            isHere = false;
            InventaryGO.SetActive(true);
        }
        else if(isHere){
        //Mouvement du Hero
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        SetParam();
        spriteRenderer.sortingOrder=-(int)Math.Floor(rb.position.y);}

    }

    public void IsBackInGame(){
        InventaryGO.SetActive(false);
        isHere = true;
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
