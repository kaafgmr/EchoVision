using UnityEngine;
using TMPro;
using System;

public class MenuTranslator : MonoBehaviour
{
	[Serializable]
	public struct MenuToTranslate
	{
		public string MenuName;
		public TextMeshProUGUI Text;
	}

	public MenuToTranslate[] menusToTranslate;

    private void OnEnable()
    {
        TranslateMenus();
    }

    public void TranslateMenus()
	{
		for (int i = 0; i < menusToTranslate.Length; i++)
		{
			menusToTranslate[i].Text.text = Translator.instance.GetMenutext(menusToTranslate[i].MenuName);
		}
	}
}