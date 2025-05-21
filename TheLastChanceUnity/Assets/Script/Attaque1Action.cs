using UnityEngine;
using System.Collections;

public class Attaque1Action : MonoBehaviour
{
    Animator anim;

    private bool canAttack = true;



    [SerializeField]
    private float timeBetweenLow = 1f;
    [SerializeField]
    private float timeBetweenHight = 0.5f;

    
    [SerializeField]
    private int typeOfAttack;

    public int TypeOfAttack{get {return typeOfAttack; } }



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    public void AttackLow()
    {
        if(1==1 || canAttack ) // A travailler plus tard!! (Jamais)
        {
            anim.SetBool("attack",true);
            canAttack = false;
            StartCoroutine(TimeWaitBetweenLow());
        }

    }

    private IEnumerator TimeWaitBetweenLow()
    {
        yield return new WaitForSeconds(timeBetweenLow);
        canAttack = true;
        anim.SetBool("attack",false);
        gameObject.SetActive(false);
    }

    public void AttackHight()
    {
        if(canAttack || 1==1 ) // A travailler plus tard!!(Non plus)
        {
            canAttack = false;
            anim.SetBool("attack",true);
            StartCoroutine(TimeWaitBetweenHight());
        }

    }

    private IEnumerator TimeWaitBetweenHight()
    {

        yield return new WaitForSeconds(timeBetweenHight);

        canAttack = true;
        
        anim.SetBool("attack",false);
        
        gameObject.SetActive(false);

    }
}
