using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float PV {get;set;}

    public float maxPV {get;set;}

    public float Damage {get;set;}

    [SerializeField]
    private int numberOfThePlayer;
    
    public GameManagerInGame gameManager;

    public Canvas ownCanvas;

    public int NumberOfThePlayer {get{return numberOfThePlayer ;} set{numberOfThePlayer=value ;} }

    public PlayerStats()
    {
        maxPV = 100f;
        PV = maxPV;
        Damage = 25f;
    }
    

}
