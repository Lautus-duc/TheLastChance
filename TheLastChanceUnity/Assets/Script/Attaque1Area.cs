using UnityEngine;
using System.Collections;
using Unity.Properties;

public class Attaque1Area : MonoBehaviour
{
    private int damage = 50;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<EnemyStat>() != null)
        {
            EnemyStat enemyStat = collider.GetComponent<EnemyStat>();
            enemyStat.RecevoirDegat(damage);
        }
    }

}
