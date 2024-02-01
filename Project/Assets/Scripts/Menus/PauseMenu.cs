using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] GameObject SettingsMenuUI;
    bool Paused = false;
    bool OnSettings = false;

    public static PauseMenu instance;

    private void Start()
    {
        instance = this;
        Resume();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);
        Paused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(false);
        Paused = false;
    }

    public bool IsPaused()
    {
        return Paused;
    }

    public void OpenSettingsMenu()
    {
        SettingsMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        OnSettings = true;
    }

    public void CloseSettingsMenu() 
    {
        SettingsMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        OnSettings = false;
    }

    public bool IsOnSettings()
    {
        return OnSettings;
    }
}