using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private Inventory_itemData _itemData;      // Референс к дате
    [SerializeField] private int _stackSize;                    // текущий размер стака предмета -- как много информации мы имеем

    public Inventory_itemData ItemData => _itemData;
    public int StackSize => _stackSize;

    public InventorySlot(Inventory_itemData source, int amount)     // Конструктор, который создаёт занятый слот инвентаря
    {
        _itemData = source;
        this._stackSize = amount;
    }

    public InventorySlot()      // Конструктор, который создаёт пустой слот инвентаря
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        _itemData = null;
        _stackSize = -1;
    }

    public void AssignItem(InventorySlot invSlot)   // Назначение предмета в определённый слот
    {
        if (_itemData == invSlot.ItemData)      // Если слот содержит тот же предмет,  
            AddToStack(invSlot._stackSize);     // то добавляем его в стак
        else                // Перезаписываем слот вместе со слотом инвентаря, который мы передаём
        {
            _itemData = invSlot.ItemData;
            _stackSize = 0;
            AddToStack(invSlot._stackSize);
        }
    }

    public void UpdateInventorySlot(Inventory_itemData data, int amoutn)    // Обновление слота напрямую
    {
        _itemData = data;
        _stackSize = amoutn;
    }

    public bool EnoughRoomLeftInStack(int amountToAdd, out int amountRemaining)   // Достаточно ли места в стаке, который мы пытаемся увеличить
    {
        amountRemaining = ItemData.MaxStackSize - _stackSize;

        return EnoughRoomLeftInStack(amountToAdd);
    }

    public bool EnoughRoomLeftInStack(int amountToAdd)
    {
        if (_itemData == null || _stackSize + amountToAdd <= _itemData.MaxStackSize)
            return true;
        else
            return false;
    }

    public void AddToStack(int amount)
    {
        _stackSize += amount;
    }

    public void RemoveFromStack(int amout)
    {
        _stackSize -= amout;
    }

    public bool SplitStack(out InventorySlot splitStack)
    {
        if (_stackSize <= 1)            // Есть ли что разделять? Если нет, возвращаем false
        {
            splitStack = null;
            return false;
        }

        int halfStack = Mathf.RoundToInt(_stackSize / 2);       // Получаем половину стака
        RemoveFromStack(halfStack);

        splitStack = new InventorySlot(ItemData, halfStack);    // Создаём копию этого слота с половиной от размера стака

        return true;
    }
}
