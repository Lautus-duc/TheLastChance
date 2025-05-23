using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Health { get; set; }
    public float maxHealth { get; set; }
    public float Damage { get; set; }
    [SerializeField]
    private int numberOfThePlayer;
    public int NumberOfThePlayer { get { return numberOfThePlayer; } set { numberOfThePlayer = value; } }

    public PlayerStats()
    {
        maxHealth = 100f;
        Health = maxHealth;
        Damage = 25f;
    }


}
