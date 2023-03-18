using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplay : InventoryDisplay
{

    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlot_UI[] slots;

    public override void Start()
    {
        base.Start();

        if (inventoryHolder != null)
        {
            Debug.LogWarning("Inventory holder is not null");
            inventorySystem = inventoryHolder.InventorySystem;
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        else 
            Debug.LogWarning($"No inventory assigned to {this.gameObject.name}");

        AssignSlot(InventorySystem);
    }

    public override void AssignSlot(InventorySystem invToDisplay)
    {
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        if (slots.Length != InventorySystem.InventorySize)
            Debug.Log($"Inventory slots out of sync on {this.gameObject}");

        for (int i = 0; i < InventorySystem.InventorySize; i++)
        {
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init(inventorySystem.InventorySlots[i]);
        }
    }

    
}
