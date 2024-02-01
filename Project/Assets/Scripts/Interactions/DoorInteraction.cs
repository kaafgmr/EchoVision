using UnityEngine;

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