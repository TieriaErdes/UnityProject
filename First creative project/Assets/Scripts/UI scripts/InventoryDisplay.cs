using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
//using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;

    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;   // ���������� ����� ���������� � ���������� �������

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;
    
    protected virtual void Start()
    {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay, int offset);      // �������������� �������� �����

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

        bool isShiftPressed = Keyboard.current.leftShiftKey.isPressed;

        // ���� ����, �� �������� ������, ����� ������� � ������ �� ����� ��������
        // �� ������� �������
        if (clickedUISlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.AssignedInventorySlot.ItemData == null)
        {
            // ���� ����� ����� ����, �� ��������� ����
            if (isShiftPressed && clickedUISlot.AssignedInventorySlot.SplitStack(out InventorySlot halfStackSlot))
            {
                mouseInventoryItem.UpdateMouseSlot(halfStackSlot);
                clickedUISlot.UpdateUISlot();
                return;
            }
            else  // ���� ������� �� ���������� �����
            {
                // ���� ����� ������������ (�� ���� ���� ����� lAlt)
                mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);
                clickedUISlot.ClearSlot();
                return;
            }
        }

        // ���� ���� ����� �� ����� ��������, �� ������ ����� �������
        // �� ��������� ������� �� ������� � ��������� ����
        if (clickedUISlot.AssignedInventorySlot.ItemData == null && mouseInventoryItem.AssignedInventorySlot.ItemData != null)
        {
            clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
            clickedUISlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot();
            return;
        }

        // ���� �� � ��� � ��� ���� ��������, ��.... � �� :)

        
        if (clickedUISlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.AssignedInventorySlot.ItemData != null)
        {
            bool isSameItem = clickedUISlot.AssignedInventorySlot.ItemData == mouseInventoryItem.AssignedInventorySlot.ItemData;

            // ��� �������� ����������? ���������� ��
            if (isSameItem && clickedUISlot.AssignedInventorySlot.EnoughRoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize))
            {
                clickedUISlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.AssignedInventorySlot);
                clickedUISlot.UpdateUISlot();

                mouseInventoryItem.ClearSlot();
                return;
            }
            else if (isSameItem &&
                !clickedUISlot.AssignedInventorySlot.EnoughRoomLeftInStack(mouseInventoryItem.AssignedInventorySlot.StackSize, out int leftInStack))
            {
                if (leftInStack < 1) SwapSlots(clickedUISlot);          // ��� ��� ���� �����, ������ ������ �������� �������
                else        // ���� �� �����, ������� ���� �� ��� ����� �� ��������� ����
                {
                    int remainingOnMouse = mouseInventoryItem.AssignedInventorySlot.StackSize - leftInStack;

                    clickedUISlot.AssignedInventorySlot.AddToStack(leftInStack);
                    clickedUISlot.UpdateUISlot();

                    var newItem = new InventorySlot(mouseInventoryItem.AssignedInventorySlot.ItemData, remainingOnMouse);
                    mouseInventoryItem.ClearSlot();
                    mouseInventoryItem.UpdateMouseSlot(newItem);
                    return;
                }
            }
            

            else if (!isSameItem)
            {
                SwapSlots(clickedUISlot);
                return;
            }
        }


    }   

    
    private void SwapSlots(InventorySlot_UI clickedUISlot)
    {
        var clonedSlot = new InventorySlot(mouseInventoryItem.AssignedInventorySlot.ItemData, mouseInventoryItem.AssignedInventorySlot.StackSize);
        mouseInventoryItem.ClearSlot();

        mouseInventoryItem.UpdateMouseSlot(clickedUISlot.AssignedInventorySlot);

        clickedUISlot.ClearSlot();
        clickedUISlot.AssignedInventorySlot.AssignItem(clonedSlot);
        clickedUISlot.UpdateUISlot();
    }
}
