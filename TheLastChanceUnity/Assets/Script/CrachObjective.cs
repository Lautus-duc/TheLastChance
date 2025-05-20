using UnityEngine;

public class CrachObjective : MonoBehaviour
{
    public GameManagerInGame gameManager;
    public void ObjectiveRecup()
    {
        gameManager.OneObjectiveCompleted();
        Destroy(gameObject);
    }
}
