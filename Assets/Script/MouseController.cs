using UnityEngine;


public enum SceneGameType{
    None,
    Game,
    Option,
    Inventory,
}


public class MouseController : MonoBehaviour
{
    [SerializeField]
    private SceneGameType sceneGameType;
    [SerializeField]
    private GameObject Attack;

    void Start()
    {
        sceneGameType = SceneGameType.Game;
    }

    public void SetScene(SceneGameType _sceneGameType){
        sceneGameType = _sceneGameType;
    }
    
    public SceneGameType GetScene(){
        return sceneGameType;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(sceneGameType == SceneGameType.Game){
                Attack.SetActive(true);
                Attack.GetComponent<Attaque1Action>().AttackLow();
            }
        }
    }

}
