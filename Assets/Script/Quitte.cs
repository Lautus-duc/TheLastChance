using UnityEngine;

public class Quitte : MonoBehaviour
{
    private GameManagerMain managager;
    private void Start()
    {
        managager = GameManagerMain.instance;
    }

    public void LeftTheGame(string ManagerGameScene){
        managager.ChangeScene(ManagerGameScene);
    }
}
