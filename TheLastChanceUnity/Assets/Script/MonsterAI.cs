using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform TargetTransform;
    public float DamageToPlayer = 10f;
    public float DamageToCampfire = 20f;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (TargetTransform == null)
        {
            FindClosestTarget();
        }
    }

    private void Update()
    {
        if (TargetTransform == null)
        {
            FindClosestTarget();
        }

        if (TargetTransform != null)
        {
            agent.SetDestination(TargetTransform.position);
            transform.LookAt(new Vector3(TargetTransform.position.x, transform.position.y, TargetTransform.position.z));
        }
    }

    private void FindClosestTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject campfire = GameObject.FindGameObjectWithTag("FireCamp");

        float closestDistance = Mathf.Infinity;
        GameObject closest = null;

        foreach (GameObject player in players)
        {
            float dist = Vector3.Distance(transform.position, player.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closest = player;
            }
        }

        if (campfire != null)
        {
            float distCamp = Vector3.Distance(transform.position, campfire.transform.position);
            if (distCamp < closestDistance)
            {
                closestDistance = distCamp;
                closest = campfire;
            }
        }

        if (closest != null)
        {
            TargetTransform = closest.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFight stats = other.GetComponent<PlayerFight>();
            if (stats != null)
            {
                stats.Health -= DamageToPlayer;
                stats.Health = Mathf.Max(stats.Health, 0);
                stats.HP_Barre_Script.ChangeBarre(stats.Health, stats.maxHealth);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("FireCamp"))
        {
            FireCamp camp = other.GetComponent<FireCamp>();
            if (camp != null)
            {
                camp.TakeDamage(DamageToCampfire);
            }
            Destroy(gameObject);
        }
    }
}

