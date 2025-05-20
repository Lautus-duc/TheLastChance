using UnityEngine;
using Photon.Pun;

public class PlayerAttack : MonoBehaviourPun
{

    private GameObject attackArea = default;
    
    [SerializeField]
    private bool isAttacking = false;

    private float timeToAct = 0.25f;
    private float timer = 0;
    [SerializeField]
    private PlayerMouvement playerMouvement;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        playerMouvement = GetComponent<PlayerMouvement>();
    }

    void Update()
    {
        if (!photonView.IsMine || !playerMouvement.isHere) return;
        if (Input.GetMouseButtonDown(0) && playerMouvement.isHere)
        {
            Attack();
        }

        if(isAttacking && playerMouvement.isHere)
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
