using UnityEngine;
using System.Collections;

public class Attaque1Action : MonoBehaviour
{
    Animator anim;

    private bool canAttack = true;



    [SerializeField]
    private float timeBetweenLow = 1.5f;
    [SerializeField]
    private float timeBetweenHight = 1.5f;

    
    [SerializeField]
    private int typeOfAttack;

    public int TypeOfAttack{get {return typeOfAttack; } }
    [SerializeField]
    private PlayerMouvement playerMouvement;



    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    public void AttackLow()
    {
        if(playerMouvement.isHere && canAttack ) // A travailler plus tard!! (Jamais)
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
    }

    public void AttackHight()
    {
        if(canAttack && playerMouvement.isHere ) // A travailler plus tard!!(Non plus)
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
        
    }
}
