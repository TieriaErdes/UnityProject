using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

     public List<InventorySlot> InventorySlots => inventorySlots;

    public int InventorySize => inventorySlots.Count;


    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(Inventory_itemData itemToAdd, int amoutToAdd)
    {
        //inventorySlots[0] = new InventorySlot(itemToAdd, amoutToAdd);
        //return true;

        // Проверяет наличие предмета в инвентаре
        if (ContainsItem(itemToAdd, out List<InventorySlot> invSlot))
        {
            foreach (var slot in invSlot)
            {
                if (slot.RoomLeftInStack(amoutToAdd))
                {
                    slot.AddToStack(amoutToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }


        // Получает первый свободный слот
        if (HasFreeSlot(out InventorySlot freeSlot))
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amoutToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }    
        
        return false;
    }

    public bool ContainsItem(Inventory_itemData itemToAdd, out List<InventorySlot> invSlot)
    {
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();  // 9:03, мог ошибиться

        return invSlot == null ? false : true;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
