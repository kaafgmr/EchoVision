using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Scripting : MonoBehaviour
{
    //scripting
    public ScriptOptions[] actionList;
    private GameObject dialogTextUI;
    private Image DialogBackgroundImage;
    private TextMeshProUGUI dialogText;
    private bool isScripting;
    private bool waiting;
    private int CommandID = 0;
    private float timer = 0;

    //custom editor
    [System.Serializable]
    public struct ScriptOptions
    {
        public enum ActionType
        {
            ShowDialogText,
            HideDialogText,
            WaitFor,
            PickItem,
            DisableObject,
            OpenInventory,
            CloseInventory,
            MakeNoise,
            Loop
        }

        public ActionType type;
        public string textInput;
        public float floatInput;
        public Item itemInput;
        public Transform transformInput;
        public NoiseMaker noiseMakerInput;
        public GameObject gameObjectInput;
    }

    private void Start()
    {
        dialogTextUI = GameManager.Instance.DialogTextUI;
        DialogBackgroundImage = GameManager.Instance.DialogBackgroundImage;
        dialogText = GameManager.Instance.Dialogtext;
        isScripting = false;
        waiting = false;
    }

    private void FixedUpdate()
    {
        if (!isScripting) return;
        if (CommandID >= actionList.Length)
        {
            if (actionList[CommandID - 1].type != ScriptOptions.ActionType.Loop)
            {
                StopScripting();
                return;
            }
        }

        InitCommand(CommandID);
        UpdateCommand(CommandID);
    }

    void InitCommand(int id)
    {
        if (actionList[id].type == ScriptOptions.ActionType.WaitFor && !waiting)
        {
            timer = actionList[id].floatInput;
            waiting = true;
        }
    }

    bool UpdateCommand(int id)
    {
        if (actionList[id].type == ScriptOptions.ActionType.WaitFor)
        {
            if (!waiting) return true;
            timer -= Time.fixedDeltaTime;
            if (timer < 0)
            {
                timer = 0;
                waiting = false;
            }
        }
        else if (actionList[id].type == ScriptOptions.ActionType.ShowDialogText)
        {
            dialogTextUI.SetActive(true);
            string colorString = Translator.instance.getCharacterTalkingOnDialog(actionList[id].textInput);
            Color CharacterColor = Color.white;
            ColorUtility.TryParseHtmlString(colorString, out CharacterColor);
            DialogBackgroundImage.color = CharacterColor;
            dialogText.text = Translator.instance.GetDialog(actionList[id].textInput);
            waiting = false;
        }
        else if (actionList[id].type == ScriptOptions.ActionType.HideDialogText)
        {
            dialogTextUI.SetActive(false);
            waiting = false;
        }
        else if (actionList[id].type == ScriptOptions.ActionType.PickItem)
        {
            InventoryManager.Instance.AddItem(actionList[id].itemInput);

            waiting = false;
        }
        else if (actionList[id].type == ScriptOptions.ActionType.OpenInventory)
        {
            InventoryAnimations.instance.OpenInventory();

            waiting = false;
        }
        else if (actionList[id].type == ScriptOptions.ActionType.CloseInventory)
        {
            InventoryAnimations.instance.CloseInventory();

            waiting = false;
        }
        else if (actionList[id].type == ScriptOptions.ActionType.MakeNoise)
        {
            actionList[id].noiseMakerInput.MakeNoise();

            waiting = false;
        }
        else if (actionList[id].type == ScriptOptions.ActionType.Loop)
        {
            CommandID = 0;

            waiting = false;
            return true;
        }
        else if (actionList[id].type == ScriptOptions.ActionType.DisableObject)
        {
            actionList[id].gameObjectInput.SetActive(false);

            waiting = false;
        }

        if (!waiting)
        {
            CommandID++;
        }
        return true;
    }

    public void StartScripting()
    {
        CommandID = 0;
        isScripting = true;
        waiting = false;
    }

    public void StopScripting()
    {
        isScripting = false;
        waiting = false;
    }

    public bool IsScripting()
    {
        return isScripting;
    }
}