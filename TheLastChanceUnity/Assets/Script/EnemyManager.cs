using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
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

    public Transform ThePlayerMostClose(Transform enemy){
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        foreach (var g in GameManager.PlayerList)
        {
            var t = g.GetComponent<Transform>();
            float distance = Vector3.Distance(enemy.position, t.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = t;
            }
        }
        return closest;
    }
}
