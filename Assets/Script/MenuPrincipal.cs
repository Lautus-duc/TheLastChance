using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PanelType{
    None,
    Main,
    Option,
    Credits,
}

public class MenuPrincipal : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField]private List<MenuPanel> panelsList = new List<MenuPanel>();
    private Dictionary<PanelType,MenuPanel> panelsDict = new Dictionary<PanelType, MenuPanel>();
    private GameManagerMain managager;
    private void Start()
    {
        managager=GameManagerMain.instance;
        foreach (var _panel in panelsList){
            if(_panel){
                panelsDict.Add(_panel.GetPanelType(), _panel);
            }
        }
        OpenOnePanel(PanelType.Main, false);
    }

    private void OpenOnePanel(PanelType _type, bool _animate){
        foreach(var _panel in panelsList){
            _panel.ChangeState(false, _animate);
        }

        if(_type != PanelType.None){
            panelsDict[_type].ChangeState(true, _animate);
        }
    }

    public void OpenPanel(PanelType _type){
        OpenOnePanel(_type,true);
    }

    public void ChangeScene(string sceneName){
        managager.ChangeScene(sceneName);
    }

    public void Quit(){
        managager.Quit();
    }
}
