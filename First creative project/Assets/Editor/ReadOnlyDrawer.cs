using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


// <summary>
// Этот класс содержит кастомный ящик атрибутов ReadOnly 
// <summary>
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    // <summary>
    // Юнити метод для рисования GUI в редакторе
    // <summary>
    // <param name> = "position">Position.</param>
    // <param name> = "property">Property.</param>
    // <param name> = "label">Label.</param>

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Сохранение значения существования прошлого GUI
        var previosGUIState = GUI.enabled;
        // Отклчение редактирования для свойства 
        GUI.enabled = false;
        // Рисование совйства
        EditorGUI.PropertyField(position, property, label);
        // Настройка значения активности предыдущего GUI
        GUI.enabled = previosGUIState;

        //base.OnGUI(position, property, label);
    }
}
