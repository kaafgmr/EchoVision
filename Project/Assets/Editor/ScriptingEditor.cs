using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

[CustomEditor(typeof(Scripting))]
[CanEditMultipleObjects]
public class ScriptingEditor : Editor
{
    SerializedProperty ActionListM;
    ReorderableList ActionList;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ActionList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
    }
    private void OnEnable()
    {
        ActionListM = serializedObject.FindProperty("actionList");
        ActionList = new ReorderableList(serializedObject, ActionListM, true, true, true, true);

        ActionList.elementHeight *= 2;
        ActionList.drawHeaderCallback = DrawHeader;
        ActionList.drawElementCallback = DrawListItems;
    }

    void DrawHeader(Rect rect)
    {
        EditorGUI.LabelField(rect, "Action order");
    }

    void DrawListItems(Rect rect, int index, bool isActive = false, bool isFocused = false)
    {
        float viewWidth = EditorGUIUtility.currentViewWidth;
        float LineHeight = EditorGUIUtility.singleLineHeight;

        SerializedProperty actionsL = ActionList.serializedProperty.GetArrayElementAtIndex(index);

        Scripting.ScriptOptions.ActionType actionType = (Scripting.ScriptOptions.ActionType)actionsL.FindPropertyRelative("type").enumValueIndex;
        EditorGUI.PropertyField(new Rect(rect.x, rect.y, viewWidth - 70, LineHeight), actionsL.FindPropertyRelative("type"), GUIContent.none);

        if (actionType == Scripting.ScriptOptions.ActionType.ShowDialogText)
        {
            EditorGUI.LabelField(new Rect(rect.x, rect.y + LineHeight, 100, LineHeight), "DialogName");
            EditorGUI.PropertyField(new Rect(rect.x + 100, rect.y + LineHeight, viewWidth - 170, LineHeight), actionsL.FindPropertyRelative("textInput"), GUIContent.none);
        }
        else if (actionType == Scripting.ScriptOptions.ActionType.WaitFor)
        {
            EditorGUI.LabelField(new Rect(rect.x, rect.y + LineHeight, 100, LineHeight), "Seconds");
            EditorGUI.PropertyField(new Rect(rect.x + 100, rect.y + LineHeight, viewWidth - 170, LineHeight), actionsL.FindPropertyRelative("floatInput"), GUIContent.none);
        }
        else if (actionType == Scripting.ScriptOptions.ActionType.PickItem)
        {
            EditorGUI.LabelField(new Rect(rect.x, rect.y + LineHeight, 100, LineHeight), "Item To Pick");
            EditorGUI.PropertyField(new Rect(rect.x + 100, rect.y + LineHeight, viewWidth - 170, LineHeight), actionsL.FindPropertyRelative("itemInput"), GUIContent.none);
        }
        else if (actionType == Scripting.ScriptOptions.ActionType.MakeNoise)
        {
            EditorGUI.LabelField(new Rect(rect.x, rect.y + LineHeight, 100, LineHeight), "NoiseMaker");
            EditorGUI.PropertyField(new Rect(rect.x + 100, rect.y + LineHeight, viewWidth - 170, LineHeight), actionsL.FindPropertyRelative("noiseMakerInput"), GUIContent.none);
        }
        else if (actionType == Scripting.ScriptOptions.ActionType.DisableObject)
        {
            EditorGUI.LabelField(new Rect(rect.x, rect.y + LineHeight, 100, LineHeight), "Object To disable");
            EditorGUI.PropertyField(new Rect(rect.x + 100, rect.y + LineHeight, viewWidth - 170, LineHeight), actionsL.FindPropertyRelative("gameObjectInput"), GUIContent.none);
        }
    }
}
