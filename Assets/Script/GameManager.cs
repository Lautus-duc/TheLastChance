using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public static GameManager Instance {get { return instance; } }

    public Transform playerInstanciate;

    [SerializeField]
    private Transform playerPrefab;

    [SerializeField]
    private PlayerFight playerFightScript;

    [SerializeField]
    private Transform SpawnPoint;

    [SerializeField]
    private GameObject particleSpawn;
    
    public Canvas canvas;
    private Canvas canvasInstanciate;
    public GameObject canvas_Barre_Script;




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
        //PlayerDeath();
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
        var clone = Instantiate(particleSpawn, playerInstanciate.position, Quaternion.identity);
        Destroy(clone, 3f);
    }


    private void PlaySoundRespawn()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();
    }
}