using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripting : MonoBehaviour
{
    [SerializeField] string MenuName;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(Translator.instance.GetMenutext(MenuName));
        }
    }
}
