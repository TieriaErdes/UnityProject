using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInventoryHolder : InventoryHolder
{
    //[SerializeField] private int secondaryInventorySize;
    //[SerializeField] protected InventorySystem secondaryInventorySystem;

    //public InventorySystem SecondatyInventorySystem => secondaryInventorySystem;

    /// <summary>
    ///  ПРИВЯЗКА КЛАВИШИ ОТКРЫТИЯ ИНВЕНТАРЯ В ЭТОМ СКРИПТЕ
    ///  В ФУНКЦИИ Update
    /// </summary>

    public static UnityAction OnPlayerInventoryChanged;

    public static UnityAction<InventorySystem, int> OnPlayerInventoryDisplayRequested;  

    private void Start()
    {
        SaveGameManager.data.playerInventory = new InventorySaveData(primaryInventorySystem);
        SaveLoad.OnLoadGame += LoadInventory;
    }

    protected override void LoadInventory(SaveData data)
    {
        // Проверяем data для конкретно этого сундука и если он существует, то загружаем его
        if (data.playerInventory.InvSystem != null)
        {
            this.primaryInventorySystem = data.playerInventory.InvSystem;
            //this.transform.position = chestData.position;
            //this.transform.rotation = chestData.rotation;
            OnPlayerInventoryChanged?.Invoke();
        }
    }

    private void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
            OnPlayerInventoryDisplayRequested?.Invoke(primaryInventorySystem, offset);
    }

    public bool AddToInventory(Inventory_itemData data, int amount)
    {
        if (primaryInventorySystem.AddToInventory(data, amount))
        {
            return true;
        }

        return false;
    }
}
