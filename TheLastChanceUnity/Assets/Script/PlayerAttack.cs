using UnityEngine;
using Photon.Pun;
using System.Linq;
using System.Collections;
using UnityEditor.Rendering;

public class PlayerAttack : MonoBehaviourPun
{

    private GameObject attackArea = default;

    [SerializeField]
    private bool isAttacking = false;
    [SerializeField]
    float timeToSwallow = 3f;
    bool canEat = true;
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
    bool HaveShovel { get => GetComponent<InventoryBackPack>().HaveShovel; }
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
            Attack();
            Hunger -= 0.75f;
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
            Hunger -= 0.5f;
            if (Hunger <= 0)
            {
                Hunger = 0;
                HungerBarre.ChangeBarre(0, MaxHunger);
                starveToDeath();
            }
            HungerBarre.ChangeBarre(Hunger, MaxHunger);
        }
        if (Input.GetKey(KeyCode.E) && canEat && playerMouvement.isHere)
        {
            canEat = false;
            inventoryBackPack.ConsomFruit();
            Hunger += 6;
            HungerBarre.ChangeBarre(Hunger, MaxHunger);
            StartCoroutine(CanEat());
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
    public void Eat()
    {
        if(canEat)
        { canEat = false;
        inventoryBackPack.ConsomFruit();
        Hunger += 6;
        HungerBarre.ChangeBarre(Hunger, MaxHunger);
        StartCoroutine(CanEat());}
    }
    public void Eat(float hunger)
    {
        if(canEat)
        { canEat = false;
        inventoryBackPack.ConsomFruit();
        Hunger += hunger;
        HungerBarre.ChangeBarre(Hunger, MaxHunger);
        StartCoroutine(CanEat());}
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
        Vector3 vector3 = new Vector3(pos.x, pos.y - 1, 1f);
        var particle = Instantiate(DigParticle, vector3, Quaternion.identity);
        float i = Random.Range(0f, 100.0f);
        if (i < 80.0f)
        {
        }
        else
        {
            inventoryBackPack.Stone += 1;
        }
        Destroy(particle, 1f);
    }

    private void DigWithShovel()
    {
        Vector3 pos = GetComponents<Transform>().First().position;
        Vector3 vector3 = new Vector3(pos.x, pos.y - 1, 1f);
        var particle = Instantiate(DigParticle, vector3, Quaternion.identity);
        float i = Random.Range(0f, 100.0f);
        if (i < 40.0f)
        {
        }
        else if (i < 95.0f)
        {
            inventoryBackPack.Stone += 1;
        }
        else
        {
            inventoryBackPack.Iron += 1;
        }
        Destroy(particle, 2f);
    }

    IEnumerator CanEat()
    {
        yield return new WaitForSeconds(timeToSwallow);
        canEat = true;
    }
}
