using UnityEngine;
using System;
using TMPro;

public class LanguageSelection : MonoBehaviour
{
    [SerializeField] TMP_Dropdown LanguageDropdown;
    public static LanguageSelection instance;

    [Serializable]
    public enum Languages
    {
        English,
        Español,
        Português,
        LENGTH
    }

    private void OnEnable()
    {
        if (LanguageDropdown != null)
        {
            LanguageDropdown.value = GetCurrentLanguageAsInt();
            LanguageDropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        }
        ChangeLanguageTo(GetCurrentLanguageAsInt());
        instance = this;
    }

    void OnDropdownValueChanged()
    {
        ChangeLanguageTo(LanguageDropdown.value);
    }

    public string GetCurrentLanguageAsString()
    {
        return PlayerPrefs.GetString("CurrentLanguage");
    }

    public int GetCurrentLanguageAsInt()
    {
        string parseString = PlayerPrefs.GetString("CurrentLanguage");
        if (parseString == "")
        {
            ChangeLanguageTo(LanguageDropdown.value);
            parseString = PlayerPrefs.GetString("CurrentLanguage");
        }

        Languages parseEnum = (Languages)Enum.Parse(typeof(Languages), parseString);
        int languageInt = (int)parseEnum;

        return languageInt;
    }

    public int GetLanguageAmount()
    {
        return LanguageDropdown.options.Count;
    }

    public string[] GetLanguageList()
    {
        string[] Languages = new string[LanguageDropdown.options.Count];

        for (int i = 0; i < LanguageDropdown.options.Count; i++)
        {
            Languages[i] = LanguageDropdown.options[i].ToString();
        }

        return Languages;
    }

    public void ChangeLanguageTo(int value)
    {
        PlayerPrefs.SetString("CurrentLanguage", ((Languages)value).ToString());
    }
}