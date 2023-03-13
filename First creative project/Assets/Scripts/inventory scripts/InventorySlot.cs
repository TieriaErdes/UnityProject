using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private Inventory_itemData _itemData;
    [SerializeField] private int _stackSize;

    public Inventory_itemData ItemData => _itemData;
    public int StackSize => _stackSize;

    public InventorySlot(Inventory_itemData source, int amount)
    {
        _itemData = source;
        this._stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        _itemData = null;
        _stackSize = -1;
    }

    public void UpdateInventorySlot(Inventory_itemData data, int amoutn)
    {
        _itemData = data;
        _stackSize = amoutn;
    }

    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining)
    {
        amountRemaining = ItemData.MaxStackSize - _stackSize;

        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        if (_stackSize + amountToAdd <= _itemData.MaxStackSize)
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
}
