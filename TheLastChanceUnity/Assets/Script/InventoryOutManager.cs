using UnityEngine;

public class InventoryOutManager : MonoBehaviour
{
    private PlayerMouvement parentMouvement;
    void Start()
    {
        parentMouvement = GetComponentInParent<PlayerMouvement>();
    }
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
        {
            parentMouvement.IsBackInGame();
        }
    }
}
