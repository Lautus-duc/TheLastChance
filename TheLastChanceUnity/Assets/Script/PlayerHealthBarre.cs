using UnityEngine;
using UnityEngine.UI;

public class PlayerBarre : MonoBehaviour
{
    [SerializeField]
    private Transform BarreTransform;
    [SerializeField]
    private Image BarreImage;
    [SerializeField]
    private Color BarreColor;
    
    public float HeightBarre= 100f;

    public void ChangeBarre(float newValue, float maxValue)
    {
        float valueActual = newValue / maxValue;
        BarreTransform.localScale = new Vector3(valueActual, BarreTransform.localScale.y, BarreTransform.localScale.z);
    }

}
