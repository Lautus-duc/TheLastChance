using UnityEngine;

public class CrachObjective : MonoBehaviour
{
    [SerializeField]
    GameManagerInGame gameManager;
    public void ObjectiveRecup()
    {
        gameManager.OneObjectiveCompleted();
        Destroy(gameObject);
    }
}
