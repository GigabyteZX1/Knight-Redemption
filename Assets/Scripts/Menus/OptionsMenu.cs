using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    Resolution[] resolutions;
    public Dropdown resDropdown;

    void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> options = new List<string>();
        int curretResolutionIndex = 0;

        for (int i = 0 ; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height )
            {
                curretResolutionIndex = i;

            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = curretResolutionIndex;
        resDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }


}
