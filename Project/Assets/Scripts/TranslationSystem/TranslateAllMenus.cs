using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateAllMenus : MonoBehaviour
{
    [SerializeField] MenuTranslator[] translators;

    public void TranslateAll()
    {
        for (int i = 0; i < translators.Length; i++)
        {
            translators[i].TranslateMenus();
        }
    }
}
