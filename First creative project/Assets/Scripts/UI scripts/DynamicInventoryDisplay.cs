using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DynamicInventoryDisplay : InventoryDisplay
{
    [SerializeField] protected InventorySlot_UI slotPrefab;

    /*protected override void Start()
    {
        base.Start();
        Debug.Log("Динамический инвентарь запущен");
    }*/

    public void RefreshDynamicInventory(InventorySystem invToDispalay, int offset)
    {
        ClearSlots();
        inventorySystem = invToDispalay;
        if (inventorySystem != null) inventorySystem.OnInventorySlotChanged += UpdateSlot;
        AssignSlot(invToDispalay, offset);
    }

    public override void AssignSlot(InventorySystem invToDisplay, int offset)
    {
        //ClearSlots();

        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        if (invToDisplay == null) return;


        for (int i = offset; i < invToDisplay.InventorySize; i++)
        {
            var uiSlots = Instantiate(slotPrefab, transform);
            slotDictionary.Add(uiSlots, invToDisplay.InventorySlots[i]);
            uiSlots.Init(invToDisplay.InventorySlots[i]);
            uiSlots.UpdateUISlot();
        }
    }

    private void ClearSlots()
    {
        foreach (var item in transform.Cast<Transform>())
        {
            Destroy(item.gameObject);
        }

        if(slotDictionary != null)
            slotDictionary.Clear();
    }

    private void OnDisable()
    {
        if (inventorySystem != null) inventorySystem.OnInventorySlotChanged -= UpdateSlot;
    }
}
