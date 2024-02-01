using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuNavigation : MonoBehaviour
{
    [SerializeField] GameObject OptionsUI;
    [SerializeField] GameObject SettingsUI;
    [SerializeField] GameObject InstructionsUI;
    public UnityEvent OnStart;
    public UnityEvent OnShowSettings;
    public UnityEvent OnShowInstructions;
    public UnityEvent OnHideAll;

    private void Start()
    {
        HideAll();
        OnStart.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideAll();
        }
    }

    public void ShowSettings()
    {
        SettingsUI.SetActive(true);
        InstructionsUI.SetActive(false);
        OptionsUI.SetActive(false);
        OnShowSettings.Invoke();
    }

    public void ShowInstructions()
    {
        InstructionsUI.SetActive(true);
        SettingsUI.SetActive(false);
        OptionsUI.SetActive(false);
        OnShowInstructions.Invoke();
    }

    public void HideAll()
    {
        InstructionsUI.SetActive(false);
        SettingsUI.SetActive(false);
        OptionsUI.SetActive(true);
        OnHideAll.Invoke();
    }
}
