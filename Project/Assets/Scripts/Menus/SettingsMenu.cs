using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Menus
{
    public string name;
    public GameObject UI;
}

public class SettingsMenu : MonoBehaviour
{
    public string defaultMenuName;
    public List<Menus> menus;
    
    string currentMenu;
    Dictionary<string, GameObject> settings;

    private void Start()
    {
        for (int i = 0; i < menus.Count; i++)
        {
            settings.Add(menus[i].name, menus[i].UI);
        }

        if (currentMenu == null)
        {
            int randMenu = UnityEngine.Random.Range(0, menus.Count);
            currentMenu = menus[randMenu].name;
        }
    }
    public void Show(string name)
    {
        if (name == currentMenu) return;

        settings[currentMenu].SetActive(false);
        settings[name].SetActive(true);
    }
}
