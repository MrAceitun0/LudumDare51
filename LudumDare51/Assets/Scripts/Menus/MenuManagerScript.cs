using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class MenuManagerScript : MonoBehaviour
{
    private const string VOLUME = "volume";
    public AudioMixer masterAudioMixer;

    List<Resolution> availableResolutions;
    public Dropdown resolutionDropdown;

    private const string IS_LOADING_SCREEN = "isLoadingScreen";
    public Animator faderAnimator;

    private void Start()
    {
        if (resolutionDropdown)
        {
            getAvailableResolutions();
        }
    }

    public void loadScene(string sceneName)
    {
        faderAnimator.SetBool(IS_LOADING_SCREEN, true);
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void setVolume(float volume)
    {
        masterAudioMixer.SetFloat(VOLUME, volume);
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resolutionIndex)
    {
        Screen.SetResolution(availableResolutions[resolutionIndex].width, availableResolutions[resolutionIndex].height, Screen.fullScreen);
    }

    public void openWebInBrowser(string url)
    {
        Application.OpenURL(url);
    }

    private void getAvailableResolutions()
    {
        availableResolutions = getUniqueResolutions();
        List<string> availableResolutionsDisplay = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < availableResolutions.Count; i++)
        {
            availableResolutionsDisplay.Add(availableResolutions[i].width + " x " + availableResolutions[i].height );
            if (availableResolutions[i].width == Screen.currentResolution.width
                && availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(availableResolutionsDisplay);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public static List<Resolution> getUniqueResolutions()
    {
        //Filters out all resolutions with low refresh rate:
        Resolution[] resolutions = Screen.resolutions;
        HashSet<Tuple<int, int>> uniqResolutions = new HashSet<Tuple<int, int>>();
        Dictionary<Tuple<int, int>, int> maxRefreshRates = new Dictionary<Tuple<int, int>, int>();
        for (int i = 0; i < resolutions.GetLength(0); i++)
        {
            //Add resolutions (if they are not already contained)
            Tuple<int, int> resolution = new Tuple<int, int>(resolutions[i].width, resolutions[i].height);
            uniqResolutions.Add(resolution);
            //Get highest framerate:
            if (!maxRefreshRates.ContainsKey(resolution))
            {
                maxRefreshRates.Add(resolution, resolutions[i].refreshRate);
            }
            else
            {
                maxRefreshRates[resolution] = resolutions[i].refreshRate;
            }
        }
        //Build resolution list:
        List<Resolution> uniqResolutionsList = new List<Resolution>(uniqResolutions.Count);
        foreach (Tuple<int, int> resolution in uniqResolutions)
        {
            Resolution newResolution = new Resolution();
            newResolution.width = resolution.Item1;
            newResolution.height = resolution.Item2;
            if (maxRefreshRates.TryGetValue(resolution, out int refreshRate))
            {
                newResolution.refreshRate = refreshRate;
            }
            uniqResolutionsList.Add(newResolution);
        }
        return uniqResolutionsList;
    }

}