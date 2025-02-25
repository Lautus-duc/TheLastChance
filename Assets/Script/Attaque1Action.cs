using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Attaque1Action : MonoBehaviour
{
    Animator anim;

    CapsuleCollider2D attackCollider;

    private Player player;

    private float timeToAct = 0;

    private bool canAttack = true;



    [SerializeField]
    private float timeBetweenLow = 0.05f;
    [SerializeField]
    private float timeBetweenHight = 0.5f;

    
    [SerializeField]
    private int typeOfAttack;

    public int TypeOfAttack{get {return typeOfAttack; } }



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        attackCollider = gameObject.GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            AttackLow();
        }

        else if(Input.GetMouseButtonDown(0) && Time.time > timeToAct)
        {
            AttackHight();
        }

        else
        {
            anim.SetBool("attack",false);
        }

    }


    private void AttackLow()
    {
        if(canAttack || 1==1 ) // A travailler plus tard!!
        {
            anim.SetBool("attack",true);
            StartCoroutine(TimeWaitBetweenLow());
        }

    }
    private IEnumerator TimeWaitBetweenLow()
    {
        canAttack = false;

        yield return new WaitForSeconds(timeBetweenLow);

        canAttack = true;

    }

    private void AttackHight()
    {
        if(canAttack || 1==1 ) // A travailler plus tard!!
        {
            canAttack = false;
            anim.SetBool("attack",true);
            StartCoroutine(TimeWaitBetweenHight());
        }
        else
        {
            anim.SetBool("attack",false);
        }

    }

    private IEnumerator TimeWaitBetweenHight()
    {

        yield return new WaitForSeconds(timeBetweenHight);

        canAttack = true;

    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log(2);
    }



}
