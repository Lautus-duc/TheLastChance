using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLight2DScript : MonoBehaviour
{
    
    [SerializeField]
    private Light2D light2D;

    public void SwitchToDay()
    {
        light2D.color = new Color(1f, 1f, 1f, 1f);
    }
    public void SwitchToNight()
    {
        light2D.color = new Color(77f / 255f, 30f / 255f, 30f / 255f);
    }
}
