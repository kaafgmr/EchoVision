using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    [SerializeField] TextAsset dialogsText;
    [SerializeField] TextAsset menuTexts;

    Dictionary<string, string[]> TranslatedDialog;
    Dictionary<string, string> CharacterTalking;

    Dictionary<string, string[]> TranslatedMenus;

    public static Translator instance;

    private void OnEnable()
    {
        if (dialogsText != null)
        {
            FillDialogDictionary();
        }

        if (menuTexts != null)
        {
            FillMenuDictionary();
        }

        instance = this;
    }
    public void FillDialogDictionary()
    {
        TranslatedDialog = new Dictionary<string,string[]>();

        string[] lines = dialogsText.text.Split("\n");
        CharacterTalking = new Dictionary<string,string>();
        for (int i = 0; i < lines.Length; i++)
        {
            string[] properties = lines[i].Split("|");
            string[] translations = new string[properties.Length - 2];
            for (int j = 2; j < properties.Length; j++)
            {
                translations[j - 2] = properties[j];
            }

            TranslatedDialog[properties[0]] = translations;
            CharacterTalking[properties[0]] = properties[1];
        }
    }

    public void FillMenuDictionary()
    {
        TranslatedMenus = new Dictionary<string, string[]>();

        string[] lines = menuTexts.text.Split("\n");
        for (int i = 0; i < lines.Length; i++)
        {
            string[] properties = lines[i].Split("|");
            string[] translations = new string[properties.Length - 1];
            for (int j = 1; j < properties.Length; j++)
            {
                translations[j - 1] = properties[j];
            }

            TranslatedMenus[properties[0]] = translations;
        }
    }
    public string GetDialog(string DialogName)
    {
        int CurrentLanguage = LanguageSelection.instance.GetCurrentLanguageAsInt();
        return TranslatedDialog[DialogName][CurrentLanguage];
    }

    public string GetMenutext(string MenuName)
    {
        int CurrentLanguage = LanguageSelection.instance.GetCurrentLanguageAsInt();

        return TranslatedMenus[MenuName][CurrentLanguage];
    }

    public string getCharacterTalkingOnDialog(string DialogName)
    {
        return CharacterTalking[DialogName];
    }
}