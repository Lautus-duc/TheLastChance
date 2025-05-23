using UnityEngine;

public class FireZoneForConstruction : MonoBehaviour
{
    [SerializeField]
    CapsuleCollider2D zoneCollider;
    void Start()
    {
        zoneCollider = GetComponent<CapsuleCollider2D>();
    }
    
    
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<FireCamp>() != null)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                collider.GetComponent<FireCamp>().Check_Inventairy();
            }
            
        }
    }
}
