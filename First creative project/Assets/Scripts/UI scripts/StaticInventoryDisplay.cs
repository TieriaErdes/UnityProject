using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplay : InventoryDisplay
{

    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlot_UI[] slots;


    private void OnEnable()
    {
        PlayerInventoryHolder.OnPlayerInventoryChanged += RefresfStaticDisplay;
    }

    private void OnDisable()
    {
        PlayerInventoryHolder.OnPlayerInventoryChanged -= RefresfStaticDisplay;
    }

    private void RefresfStaticDisplay()
    {
        if (inventoryHolder != null)
        {
            Debug.LogWarning($"Inventory holder of  {this.gameObject.name} is not null");
            inventorySystem = inventoryHolder.PrimaryInventorySystem;
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        }
        else
            Debug.LogWarning($"No inventory assigned to {this.gameObject.name}");

        AssignSlot(inventorySystem, 0);
    }

    protected override void Start()
    {
        base.Start();

        RefresfStaticDisplay();
    }

    public override void AssignSlot(InventorySystem invToDisplay, int offset)
    {
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        //if (slots.Length != InventorySystem.InventorySize)
          //  Debug.Log($"Inventory slots out of sync on {this.gameObject}");

        for (int i = 0; i < inventoryHolder.Offset; i++)
        {
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init(inventorySystem.InventorySlots[i]);
        }
    }

    
}
