using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Dropdown resolution0;
    public Dropdown quallity0;

    Resolution[] resolutions;

    void Start()
    {
        resolution0.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolution0.AddOptions(options);
        resolution0.RefreshShownValue();
        LoadSetting(currentResolutionIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuallity(int quallityIndex)
    {
        QualitySettings.SetQualityLevel(quallityIndex);
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QuallitySettingPreference", quallity0.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolution0.value);
        PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }
    public void LoadSetting(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QuallitySettingPreference"))
            quallity0.value = PlayerPrefs.GetInt("QuallitySettingPreference");
        else
            quallity0.value = 3;
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolution0.value = PlayerPrefs.GetInt("ResolutionPreference");
        else 
            resolution0.value = currentResolutionIndex;
        if (PlayerPrefs.HasKey("FullScreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
        else 
            Screen.fullScreen = true;
    }
}
