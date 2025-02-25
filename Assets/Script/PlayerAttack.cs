using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private GameObject attackArea = default;
    
    [SerializeField]
    private bool isAttacking = false;

    private float timeToAct = 0.25f;
    private float timer = 0;
    
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if(isAttacking)
        {
            timer += Time.deltaTime;

            if(timer>=timeToAct)
            {
                timer = 0;
                isAttacking = false;
                attackArea.SetActive(isAttacking);
            }
        }
    }

    private void Attack()
    {
        isAttacking = true;
        attackArea.SetActive(isAttacking);
    }
}
