using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoSettings : MonoBehaviour
{
    public TMP_Dropdown ResolutionsDropdown;
    Resolution[] resolutions;
    

    private void Start()
    {
        int currentResolutionId = 0;
        resolutions = Screen.resolutions;
        ResolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionId = i;
            }
        }

        ResolutionsDropdown.AddOptions(options);
        ResolutionsDropdown.value = currentResolutionId;
        ResolutionsDropdown.RefreshShownValue();
    }


    public void SetResolution(int ResolutionId)
    {
        Screen.SetResolution(resolutions[ResolutionId].width, resolutions[ResolutionId].height, Screen.fullScreen);
    }
}
