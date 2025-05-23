using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class GameManagerInGame : MonoBehaviourPunCallbacks
{


    private static GameManagerInGame instance;

    public static GameManagerInGame Instance { get { return instance; } }

    public int numberOfObjectives = 3;


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
    [SerializeField]
    private EnemyManager enemyManager;


    [Header("timer")]
    public float timerDurationDay = 10f;
    public float timerDurationNight = 10f;
    private float timer;
    public bool isDay;
    public bool switchTime = false;

    [Header("Player")]
    public List<GameObject> PlayerList;
    private bool playerAlreadyInstantiated = false;
    public GameObject playerInstanciate;
    private int NumberOfPlayer = 0;
    private bool canInstanciate = true;




    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }


    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady && !playerAlreadyInstantiated)
        {
            while (!canInstanciate)
            {

            }
            InstantiatePlayer();
            playerAlreadyInstantiated = true;
            NumberOfPlayer = 0;
        }
    }


    void Start()
    {
        isDay = true;
        globalLight2DScript.SwitchToDay();
        tilemapRanderScript.SwitchToDay();
        timer = timerDurationDay;
    }

    void Update()
    {
        if (switchTime)
        {
            switchTime = false;
            SwitchToNextPart();
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (isDay)
            {
                timer = timerDurationNight;
            }
            else
            {
                timer = timerDurationDay;
            }
            SwitchToNextPart();
        }
    }


    private void InstantiatePlayer()
    {
        canInstanciate = false;
        Debug.Log($"Instantiating player for {PhotonNetwork.NickName}");

        playerInstanciate = PhotonNetwork.Instantiate(playerPrefab.name, SpawnPoint.position, Quaternion.identity);
        PlayerList.Add(playerInstanciate);

        Debug.Log($"Total players in scene: {PlayerList.Count}");

        playerFightScript = playerInstanciate.GetComponent<PlayerFight>();
        playerFightScript.gameManager = this;
        StartCoroutine(WaitTheNextSpawn());
        canInstanciate = true;
    }

    // PlayerDeath

    public void PlayerDeath()
    {
        if (PlayerList.Count < 2)
        {
            Destroy(playerInstanciate.gameObject);
            StartCoroutine(RespawnPlayer());
        }
        else
        {
            Debug.Log("Necessite to specify which player to destroy");
        }
    }

    public void PlayerDeath(GameObject playerGO)
    {
        PlayerList.Remove(playerGO);
        playerGO.GetComponent<PlayerMouvement>().HandleDeath();
        StartCoroutine(RespawnPlayer());
    }

    // Respawn Player

    private IEnumerator RespawnPlayer()
    {
        PlaySoundRespawn();
        yield return new WaitForSeconds(6.4f);
        while (!canInstanciate)
        {
            
        }
        InstantiatePlayer();
        SpawnParticle();
        NumberOfPlayer = 0;
    }


    // Spawn Particles
    private void SpawnParticle()
    {
        Vector3 pos = playerInstanciate.GetComponents<Transform>().First().position;
        Vector3 vector3 = new Vector3(pos.x, pos.y, 1f);
        var clone = Instantiate(particleSpawn, vector3, Quaternion.identity);
        Destroy(clone, 3f);
    }
    private void SpawnParticle(Transform playerTransform)
    {
        Vector3 vector3 = new Vector3(playerTransform.position.x, playerTransform.position.y, 1f);
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
        if (isDay)
        {
            isDay = false;
            globalLight2DScript.SwitchToNight();
            tilemapRanderScript.SwitchToNight();
            enemyManager.WaveForNight(4-numberOfObjectives,4-numberOfObjectives);


        }
        else
        {
            isDay = true;
            globalLight2DScript.SwitchToDay();
            tilemapRanderScript.SwitchToDay();
        }
    }

    IEnumerator WaitTheNextSpawn()
    {
        yield return new WaitForSeconds(1f);
    }

    public int NextNPforPlayer()
    {
        NumberOfPlayer += 1;
        return NumberOfPlayer;
    }


    public void OneObjectiveCompleted()
    {
        numberOfObjectives -= 1;
    }

    public void TheEndOfGame()
    {
        Debug.Log("Fin!!");
    }

    public void GameOver()
    {
        Debug.Log("Perdu!!");
    }
}