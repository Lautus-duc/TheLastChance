using System.Linq;
using UnityEngine;

public class Attaque1Area : MonoBehaviour
{
    [SerializeField]
    GameObject ShovelObjectiveParticle;
    [SerializeField]
    InventoryBackPack inventoryBackPack;
    private int damage = 50;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip WoodClip;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyStat>() != null)
        {
            EnemyStat enemyStat = collider.GetComponent<EnemyStat>();
            if (enemyStat.RecevoirDegat(damage)!=false)
            {
                inventoryBackPack.Gold += Random.Range(0, 2);
            }
        }
        else if (collider.GetComponent<CrachObjective>() != null)
        {
            collider.GetComponent<CrachObjective>().ObjectiveRecup();
        }
        else if (collider.GetComponent<Vegetation>() != null)
        {
            PlaySoundWood();
            (bool b, var fruit) = collider.GetComponent<Vegetation>().IsHit();
            if (b)
            {
                inventoryBackPack.Wood += 1;
            }
            inventoryBackPack.AddFruit(fruit);
        }
        else if (collider.tag == "Crafter")
        {
            if (inventoryBackPack.CreateAShovel())
            {
                Vector3 pos = GetComponents<Transform>().First().position;
                Vector3 vector3 = new Vector3(pos.x, pos.y - 1, 1f);
                var particle = Instantiate(ShovelObjectiveParticle, vector3, Quaternion.identity);
                Destroy(particle, 6.5f);
            }
        }
    }

    private void PlaySoundWood()
    {
        audioSource.PlayOneShot(WoodClip,0.5f);
    }

}
