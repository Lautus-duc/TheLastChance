using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject particleEnemyDeath;

    [SerializeField]
    private int numberOfVague = 3;
    
    [SerializeField]
    private float timerBetweenEnnemi = 5f;

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
        StartCoroutine("SpawnEnum");
        //Pour la présentation
        for (int i = 0; i<nRank; i++)
        {
            InstantiateEnemy(SpawnPoint);
        }
    }

    public IEnumerable SpawnEnum()
    {
        yield return new WaitForSeconds(6);
        while (numberOfVague > 0)
        {
            yield return new WaitForSeconds(timerBetweenEnnemi);
            for (int i = 0; i<nRank; i++)
            {
                InstantiateEnemy(SpawnPoint);
            }
            numberOfVague-=1;
        }

    }

    private void SpawnEnemyTimerCour()
    {
        if (numberOfVague > 0)
        {
            if(timer>Time.time-timerBetweenEnnemi)
            {
                for (int i = 0; i<nRank; i++)
                {
                    InstantiateEnemy(SpawnPoint);
                }
                timer = Time.time;
                numberOfVague-=1;

            }
        }
    }


    private void InstantiateEnemy(Transform spawnPoint)
    {
        enemyInstanciate = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemyInstanciate.GetComponent<Enemy1>().EnemyManager = GetComponent<EnemyManager>();
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

        return (x1 - x2)*(x1 - x2) + (y1 - y2)*(y1 - y2);
    }
}
