using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
// Это скиптовый объект, который определяет что за предмет в игру
// Это может быть унаследован из разветвлённой ветки предметов, по типу еда и экипировка
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
    /// TODO: Сделать механику использования предметов
    /// </summary>
    public void UseItem()
    {
        Debug.Log($"Using {DisplayName}");
    }
}
