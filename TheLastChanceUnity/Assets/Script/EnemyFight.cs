using Unity.VisualScripting;
using UnityEngine;

public class EnemyFight : EnemyStat
{

    [SerializeField]
    private CircleCollider2D AttackCollider;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<PlayerStats>() != null)
        {
            PlayerFight plF = collider.GetComponent<PlayerFight>();
            plF.GetDammages(Damage);
        }
    }
}
