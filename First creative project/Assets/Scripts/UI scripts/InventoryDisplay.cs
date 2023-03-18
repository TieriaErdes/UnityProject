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
            if (slot.Value == updatedSlot)          // �������� ����� �������� � ���� inventory slot.
            {
                slot.Key.UpdateUISlot(updatedSlot); // ���� ����� ��� UI ������������� ��������
            }
        }
        //.Log("Slot updated");
    }

    public void SlotClicked(InventorySlot_UI clickedUISlot)
    {
        //Debug.Log("Slot clicked");


        // ���� ����, �� �������� ������, ����� ������� � ������ �� ����� ��������
        // �� ������� �������
        if (clickedUISlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.AssignedInventorySlot.ItemData == null)
        {
            // ���� ����� ������������ (�� ���� ���� ����� lAlt)

            mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
            clickedUISlot.ClearSlot();
            return;
        }

        // ���� ���� ����� �� ����� ��������, �� ������ ����� �������
        // �� ��������� ������� �� ������� � ��������� ����
        if (clickedUISlot.AssignedInventorySlot.ItemData == null && mouseInventoryItem.AssignedInventorySlot.ItemData != null)
        {
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
        }

        // ���� �� � ��� � ��� ���� ��������, ��.... � �� :)
    }
}
