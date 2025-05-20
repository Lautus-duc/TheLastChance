using UnityEngine;
using Photon.Pun;
using UnityEngine.Assertions.Must;
using Photon.Pun.Demo.PunBasics;

public class PlayerAttack : MonoBehaviourPun
{

    private GameObject attackArea = default;
    
    [SerializeField]
    private bool isAttacking = false;

    private float timeToAct = 0.25f;
    private float timer = 0;
    [SerializeField]
    private PlayerMouvement playerMouvement;
    
    [SerializeField]
    private PlayerBarre HungerBarre;
    [SerializeField]
    private GameManagerInGame gameManager;
    float MaxHunger = 100;
    float Hunger;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("PlayerGameManager").GetComponent<GameManagerInGame>();
        attackArea = transform.GetChild(0).gameObject;
        playerMouvement = GetComponent<PlayerMouvement>();
        Hunger = MaxHunger;
    }

    void Update()
    {
        if (!photonView.IsMine || !playerMouvement.isHere) return;
        if (Input.GetMouseButtonDown(0) && playerMouvement.isHere)
        {
            Attack();
            Hunger -= 2;
            if (Hunger <= 0)
            {
                Hunger = 0;
                HungerBarre.ChangeBarre(0, MaxHunger);
                starveToDeath();
            }
            HungerBarre.ChangeBarre(Hunger, MaxHunger);
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
    private void starveToDeath()
    {
        gameManager.PlayerDeath(gameObject);
    }

    private void Attack()
    {
        isAttacking = true;
        attackArea.SetActive(isAttacking);
    }
}
