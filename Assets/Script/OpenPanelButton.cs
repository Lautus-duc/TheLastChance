using UnityEngine;

public class OpenPanelButton : MonoBehaviour
{
    [SerializeField] private PanelType type;

    private MenuPrincipal controller;

    void Start()
    {
        controller = FindFirstObjectByType<MenuPrincipal>();
    }
    public void OnClick(){
        controller.OpenPanel(type);
    }
}
