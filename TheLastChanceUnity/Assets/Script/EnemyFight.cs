using Unity.VisualScripting;
using UnityEngine;

public class EnemyFight : EnemyStat
{

    [SerializeField]
    private CircleCollider2D AttackCollider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerStats>() != null)
        {
            PlayerFight plF = collider.GetComponent<PlayerFight>();
            plF.GetDammages(Damage);
        }
        else if (collider.GetComponent<FireCamp>() != null)
        {
            FireCamp fireCamp = collider.GetComponent<FireCamp>();
            fireCamp.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
