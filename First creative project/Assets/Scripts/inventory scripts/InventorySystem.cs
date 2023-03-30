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

    public InventorySystem(int size)            //  онструктор, который задаЄт количество слотов
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

        // ѕровер€ет наличие предмета в инвентаре
        if (ContainsItem(itemToAdd, out List<InventorySlot> invSlot))
        {
            foreach (var slot in invSlot)
            {
                if (slot.EnoughRoomLeftInStack(amoutToAdd))
                {
                    slot.AddToStack(amoutToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }


        // ѕолучает первый свободный слот
        if (HasFreeSlot(out InventorySlot freeSlot))
        {
            if (freeSlot.EnoughRoomLeftInStack(amoutToAdd))
            {
                freeSlot.UpdateInventorySlot(itemToAdd, amoutToAdd);
                OnInventorySlotChanged?.Invoke(freeSlot);
                return true;
            }
            // добавить реализацию того, чтобы можно было получать то, что лежит в стаке
            // и искать следующий свободный слот, чтобы поместить туда остаток
        }    
        
        return false;
    }

    public bool ContainsItem(Inventory_itemData itemToAdd, out List<InventorySlot> invSlot)     // ≈сть ли в наших слотах предметы, которые можно было бы добавить
    {
        // ≈сли да, то получаем список их всех 
        invSlot = InventorySlots.Where(i => i.ItemData == itemToAdd).ToList();  // 9:03, мог ошибитьс€

        return invSlot == null ? false : true;      // если да, то вовращает true
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        freeSlot = InventorySlots.FirstOrDefault(i => i.ItemData == null);      // ѕолучает первый свободный слот
        return freeSlot == null ? false : true;
    }
}
