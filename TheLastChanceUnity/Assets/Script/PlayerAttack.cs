using UnityEngine;
using Photon.Pun;
using System.Linq;

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
    bool HaveShovel {get => GetComponent<InventoryBackPack>().HaveShovel;}
    [SerializeField]
    InventoryBackPack inventoryBackPack;

    [SerializeField]
    GameObject DigParticle;
    [SerializeField]
    AudioClip ShovelSong;


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
            Debug.Log(1);
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
        if (Input.GetMouseButtonDown(1) && playerMouvement.isHere)
        {
            PlaySoundShovel();
            if (HaveShovel)
            {
                DigWithShovel();
            }
            else
            {
                DigWithoutShovel();
            }
            Hunger -= 1;
            if (Hunger <= 0)
            {
                Hunger = 0;
                HungerBarre.ChangeBarre(0, MaxHunger);
                starveToDeath();
            }
            HungerBarre.ChangeBarre(Hunger, MaxHunger);
        }

        if (isAttacking && playerMouvement.isHere)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAct)
            {
                timer = 0;
                isAttacking = false;
            }
        }
    }
    private void PlaySoundShovel()
    {
        var audio = GetComponent<AudioSource>();
        audio.PlayOneShot(ShovelSong);
    }

    private void starveToDeath()
    {
        gameManager.PlayerDeath(gameObject);
    }

    private void Attack()
    {
        isAttacking = true;
    }

    private void DigWithoutShovel()
    {
        Vector3 pos = GetComponents<Transform>().First().position;
        Vector3 vector3 = new Vector3(pos.x, pos.y-1, 1f);
        var particle = Instantiate(DigParticle, vector3, Quaternion.identity);
        float i = Random.Range(0f, 100.0f);
        if (i < 80.0f)
        {
            Debug.Log("Nothing");
        }
        else
        {
            Debug.Log("Stone");
            inventoryBackPack.Stone+=1;
        }
        Destroy(particle, 1f);
    }

    private void DigWithShovel()
    {
        Vector3 pos = GetComponents<Transform>().First().position;
        Vector3 vector3 = new Vector3(pos.x, pos.y-1, 1f);
        var particle = Instantiate(DigParticle, vector3, Quaternion.identity);
        float i = Random.Range(0f, 100.0f);
        if (i < 40.0f)
        {
            Debug.Log("Nothing");
        }
        else if (i < 95.0f)
        {
            Debug.Log("Stone");
            inventoryBackPack.Stone += 1;
        }
        else
        {
            Debug.Log("Iron");
            inventoryBackPack.Iron += 1;
        }
        Destroy(particle, 2f);
    }
}
