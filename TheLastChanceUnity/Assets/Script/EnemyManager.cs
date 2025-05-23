
using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField]
    private GameObject particleEnemyDeath;

    [SerializeField]
    private int numberOfVague = 3;

    [SerializeField]
    private float timerBetweenEnnemi = 5f;

    Transform fireCamp;

    private float timer = 0f;

    [SerializeField]
    private int nRank = 1;

    private Transform enemyInstanciate;

    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private Transform SpawnPoint;

    public GameManagerInGame GameManager;


    void Start()
    {
        GameManager = GetComponent<GameManagerInGame>();
        StartCoroutine(SpawnEnum());
        //Pour la présentation
        for (int i = 0; i < nRank; i++)
        {
            InstantiateEnemy(SpawnPoint);
        }
        StartCoroutine(LoopForEnemiToPlayer());
    }

    public IEnumerator SpawnEnum()
    {
        yield return new WaitForSeconds(6);
        while (numberOfVague > 0)
        {
            yield return new WaitForSeconds(timerBetweenEnnemi);
            for (int i = 0; i < nRank; i++)
            {
                InstantiateEnemy(SpawnPoint);
            }
            numberOfVague -= 1;
        }

    }

    private void SpawnEnemyTimerCour()
    {
        if (numberOfVague > 0)
        {
            if (timer > Time.time - timerBetweenEnnemi)
            {
                for (int i = 0; i < nRank; i++)
                {
                    InstantiateEnemy(SpawnPoint);
                }
                timer = Time.time;
                numberOfVague -= 1;

            }
        }
    }


    private void InstantiateEnemy(Transform spawnPoint)
    {
        enemyInstanciate = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemyInstanciate.GetComponent<Enemy1>().EnemyManager = GetComponent<EnemyManager>();
    }
    private void InstantiateEnemyToPlayer(Transform player)
    {
        float x = Random.Range(-5f, 5f);
        if (x >= 0) x += 7;
        else x -= 7;
        float y = Random.Range(-5f, 5f);
        if (y >= 0) y += 7;
        else y -= 7;
        Vector3 nextPos = new Vector3(player.position.x + x, player.position.y + y);
        enemyInstanciate = Instantiate(enemyPrefab, nextPos, Quaternion.identity);
        enemyInstanciate.GetComponent<Enemy1>().targetTransform = player;
        enemyInstanciate.GetComponent<Enemy1>().EnemyManager = GetComponent<EnemyManager>();
    }

    private void InstantiateEnemyToFireCamp()
    {
        if (fireCamp == null) fireCamp = GameObject.FindGameObjectWithTag("FireCamp").GetComponent<Transform>();
        float x = Random.Range(-5f, 5f);
        if (x >= 0) x += 7;
        else x -= 7;
        float y = Random.Range(-5f, 5f);
        if (y >= 0) y += 7;
        else y -= 7;
        Vector3 nextPos = new Vector3(fireCamp.position.x + x, fireCamp.position.y + y);
        enemyInstanciate = Instantiate(enemyPrefab, nextPos, Quaternion.identity);
        enemyInstanciate.GetComponent<Enemy1>().targetTransform = fireCamp;
        enemyInstanciate.GetComponent<Enemy1>().EnemyManager = GetComponent<EnemyManager>();
    }

    public void WaveForNight(int numberOfwave, int numberOfEnemi)
    {
        for (int i = 0; i < nRank * 2; i++) InstantiateEnemyToFireCamp();
    }


    public void ParticleEnemyDeath(Transform enemy)
    {
        Vector3 vector3 = new Vector3(enemy.position.x, enemy.position.y, 1f);
        var clone = Instantiate(particleEnemyDeath, vector3, Quaternion.identity);
        Destroy(clone, 3f);
    }

    public Transform ThePlayerMostClose(Transform enemy, string typeOfTarget)
    {
        GameObject[] newtargetsPlayer = GameObject.FindGameObjectsWithTag(typeOfTarget);
        Transform closest = newtargetsPlayer[0].GetComponent<Transform>();
        float posClose = 800;

        foreach (var targetPlayerIN in newtargetsPlayer)
        {
            float newpos = GetDistance(targetPlayerIN.GetComponent<Transform>());
            if (newpos < posClose)
            {
                closest = targetPlayerIN.GetComponent<Transform>();
                posClose = newpos;
            }
        }
        return closest;
    }
    private float GetDistance(Transform transform)
    {
        if (transform is null) return 800;

        float x2 = transform.position.x;
        float y2 = transform.position.y;
        float x1 = GetComponent<Transform>().position.x;
        float y1 = GetComponent<Transform>().position.y;

        return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
    }



    private IEnumerator LoopForEnemiToPlayer()
    {
        yield return new WaitForSeconds(12f + Random.Range(0,7));
        var pls = GameObject.FindGameObjectsWithTag("Player");
        if (pls.Count() > 0) InstantiateEnemyToPlayer(pls[Random.Range(0, pls.Count() - 1)].GetComponent<Transform>());
        LoopForEnemiToPlayer();
    }
}
