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

    public float value = 100f;
    
    public float HeightBarre = 100f;

    public void ChangeBarre(float newValue, float maxValue)
    {
        if (newValue > maxValue) newValue = maxValue;
        value = newValue;
        float valueActual = newValue / maxValue;
        BarreTransform.localScale = new Vector3(valueActual, BarreTransform.localScale.y, BarreTransform.localScale.z);
    }
    public void ChangeBarre(float newValue)
    {
        if (newValue > HeightBarre) newValue = HeightBarre;
        value = newValue;
        float valueActual = newValue / HeightBarre;
        BarreTransform.localScale = new Vector3(valueActual, BarreTransform.localScale.y, BarreTransform.localScale.z);
    }

}