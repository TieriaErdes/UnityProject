using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
// ��� ��������� ������, ������� ���������� ��� �� ������� � ����
// ��� ����� ���� ����������� �� ������������ ����� ���������, �� ���� ��� � ����������
// <summary>

[CreateAssetMenu(menuName = "Inventory System/Inventory item")]

public class Inventory_itemData : ScriptableObject
{
    public int ID = -1;
    public string DisplayName;
    [TextArea(4, 4)]
    public string Description;
    public Sprite Icon;
    public int MaxStackSize;
    public int Value;
    public GameObject ItemPrefab;


    /// <summary>
    /// TODO: ������� �������� ������������� ���������
    /// </summary>
    public void UseItem()
    {
        Debug.Log($"Using {DisplayName}");
    }
}
