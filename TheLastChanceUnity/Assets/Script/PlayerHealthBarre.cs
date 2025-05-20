using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarre : CanvaMain
{
    [SerializeField]
    private Transform PV_BarreTransform;
    [SerializeField]
    private Image PV_BarreImage;
    [SerializeField]
    private Color PV_BarreColor;
    
    public float HeightBarre_PV= 100f;

    public void ChangeBarrePV(float pv, float pvMax)
    {

        float valueActual = pv / pvMax;
        PV_BarreTransform.localScale = new Vector3(valueActual, PV_BarreTransform.localScale.y, PV_BarreTransform.localScale.z);

    }

}
