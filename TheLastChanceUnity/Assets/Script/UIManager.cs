using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject transitionScreen;

    public void HideTransition()
    {
        transitionScreen.SetActive(false);
    }
}
