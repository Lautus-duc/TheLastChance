using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerInGame : MonoBehaviour
{

    private static GameManagerInGame instance;

    public static GameManagerInGame Instance {get { return instance; } }

    public Transform playerInstanciate;

    [SerializeField]
    private Transform playerPrefab;

    [SerializeField]
    private PlayerFight playerFightScript;

    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]
    private GameObject particleSpawn;
    [SerializeField]
    private GlobalLight2DScript globalLight2DScript;
    [SerializeField]
    private TilemapRanderScript tilemapRanderScript;
    
    public Canvas canvas;
    public GameObject canvas_Barre_Script;


    [Header ("timer")]
    public float timerDurationDay = 10f;
    public float timerDurationNight = 10f;
    private float timer;
    public bool isDay;
    public bool switchTime = false;




    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }


    void Start()
    {
        InstantiatePlayer();
        isDay = true;
        globalLight2DScript.SwitchToDay();
        tilemapRanderScript.SwitchToDay();

        timer = timerDurationDay;
    }

    void Update()
    {
        if(switchTime){
            switchTime = false;
            SwitchToNextPart();
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if(isDay){
                timer = timerDurationNight;
            }
            else{
                timer = timerDurationDay;
            }
            SwitchToNextPart();
        }
    }


    private void InstantiatePlayer()
    {
        playerInstanciate = Instantiate(playerPrefab, SpawnPoint.position, Quaternion.identity);

        playerFightScript = playerInstanciate.GetComponent<PlayerFight>();

        playerFightScript.gameManager = this;
    }

    public void PlayerDeath()
    {
        Destroy(playerInstanciate.gameObject);
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        PlaySoundRespawn();

        yield return new WaitForSeconds(6.4f);

        InstantiatePlayer();

        SpawnParticle();
    }


    private void SpawnParticle()
    {
        Vector3 vector3 = new Vector3(playerInstanciate.position.x, playerInstanciate.position.y, 1f);
        var clone = Instantiate(particleSpawn, vector3, Quaternion.identity);
        Destroy(clone, 3f);
    }


    private void PlaySoundRespawn()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();
    }


    public void SwitchToNextPart()
    {
        if (isDay){
            isDay = false;
            globalLight2DScript.SwitchToNight();
            tilemapRanderScript.SwitchToNight();
            
        }
        else{
            isDay = true;
            globalLight2DScript.SwitchToDay();
            tilemapRanderScript.SwitchToDay();
        }
    }
}