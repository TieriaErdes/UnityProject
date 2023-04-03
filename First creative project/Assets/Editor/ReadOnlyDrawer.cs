using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


// <summary>
// ���� ����� �������� ��������� ���� ��������� ReadOnly 
// <summary>
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    // <summary>
    // ����� ����� ��� ��������� GUI � ���������
    // <summary>
    // <param name> = "position">Position.</param>
    // <param name> = "property">Property.</param>
    // <param name> = "label">Label.</param>

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // ���������� �������� ������������� �������� GUI
        var previosGUIState = GUI.enabled;
        // ��������� �������������� ��� �������� 
        GUI.enabled = false;
        // ��������� ��������
        EditorGUI.PropertyField(position, property, label);
        // ��������� �������� ���������� ����������� GUI
        GUI.enabled = previosGUIState;

        //base.OnGUI(position, property, label);
    }
}
