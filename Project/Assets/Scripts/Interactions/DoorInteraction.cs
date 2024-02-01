using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] Item ItemToOpen;
    [SerializeField] string LevelToLoadIfOpen;
    [SerializeField] Scripting NeedKeyScript;

    public void Interact()
    {
        if (InventoryManager.Instance.HasItem(ItemToOpen))
        {
            MenuControl.instance.LoadScene(LevelToLoadIfOpen);
        }
        else
        {
            NeedKeyScript.StartScripting();
        }
    }
}