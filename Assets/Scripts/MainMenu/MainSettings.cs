using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSettings : MonoBehaviour
{
    public Toggle toggleFullScreen;
    public Slider volumeSlider;

    private Resolution currectResolutionFullScreen;
    // Start is called before the first frame update
    void Start()
    {
        currectResolutionFullScreen = Screen.currentResolution;
        SetVolumeSliderValue();
        toggleFullScreen.isOn = Screen.fullScreen;
    }

    public void SetVolumeSliderValue()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ChangeScreenMode()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("Screen mode changed");
        if (toggleFullScreen.isOn == false)
        {
            Screen.SetResolution(800, 600, false);
        }
        else
        {
            Screen.SetResolution(currectResolutionFullScreen.width, currectResolutionFullScreen.height, true);
        }
    }
}
