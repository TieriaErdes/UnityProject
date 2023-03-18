using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;
    
    public virtual void Start()
    {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in slotDictionary)
        {
            if (slot.Value == updatedSlot)          // Значение слота спрятано в коде inventory slot.
            {
                slot.Key.UpdateUISlot(updatedSlot); // Ключ слота это UI представление значения
            }
        }
        //.Log("Slot updated");
    }

    public void SlotClicked(InventorySlot_UI clickedUISlot)
    {
        //Debug.Log("Slot clicked");


        // Если слот, по которому нажали, имеет предмет и курсор не имеет предмета
        // то поднять предмет
        if (clickedUISlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.AssignedInventorySlot.ItemData == null)
        {
            // Если мышка отображается (то есть если нажат lAlt)

            mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
            clickedUISlot.ClearSlot();
            return;
        }

        // Если слот имеет не имеет предмета, но курсор имеет предмет
        // то поместить предмет из курсора в свободный слот
        if (clickedUISlot.AssignedInventorySlot.ItemData == null && mouseInventoryItem.AssignedInventorySlot.ItemData != null)
        {
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
        }

        // Если же и там и там есть предметы, то.... я хз :)
    }
}
