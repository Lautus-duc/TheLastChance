using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using Unity.Mathematics;
using System.Collections.Generic;

public class Options : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private AudioMixer mixerMaster;
    private Resolution[] resolutions;
    private int currentResolutionID;

    private void Awake()
    {
        resolutionDropDown.ClearOptions();
        resolutions = Screen.resolutions;

        List<string> _resolutionLabels = new List<string>();

        for (int i = 0; i<resolutions.Length;i++){
            _resolutionLabels.Add(resolutions[i].ToString());
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                currentResolutionID = i;
            }
        }

        resolutionDropDown.AddOptions(_resolutionLabels);


        resolutionDropDown.value = currentResolutionID;
        fullScreenToggle.isOn = Screen.fullScreen;
        mixerMaster.GetFloat("Master",out float _volume);
        volumeSlider.value = Mathf.InverseLerp(-80f,5f,_volume);


        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        resolutionDropDown.onValueChanged.AddListener(UpdateResolution);
        fullScreenToggle.onValueChanged.AddListener(ToggleFullScreen);
    }

    private void UpdateVolume(float _value)
    {
        mixerMaster.SetFloat("Master", Mathf.Lerp(-80,5,_value));
    }
    private void UpdateResolution(int _value)
    {
        currentResolutionID=_value;
        Screen.SetResolution(resolutions[currentResolutionID].width,resolutions[currentResolutionID].height, Screen.fullScreen);
    }
    private void ToggleFullScreen(bool _value)
    {
        Screen.fullScreen=_value;
    }

}
