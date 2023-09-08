using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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
        //SaveGameManager.data.playerInventory = new InventorySaveData(primaryInventorySystem);
        SaveGameManager.data.playerInventory = new InventorySaveData(primaryInventorySystem, transform.parent.position, transform.parent.rotation);
        SaveLoad.OnLoadGame += LoadInventory;

        InvokeRepeating("AutoPer10Seconds", 0, 10.0f);          // Запускается раз в минуту
    }

    protected override void LoadInventory(SaveData data)
    {
        // Проверяем data для конкретно этого сундука и если он существует, то загружаем его
        if (data.playerInventory.InvSystem != null)
        {
            Debug.Log("Loading inventory data");

            this.primaryInventorySystem = data.playerInventory.InvSystem;
            //this.transform.position = chestData.position;
            //this.transform.rotation = chestData.rotation;
            this.transform.parent.position = data.playerInventory.Position;
            this.transform.parent.rotation = data.playerInventory.Rotation;
            //this.transform.localPosition = data.playerInventory.LocalPosotion;
            //this.transform.localRotation = data.playerInventory.LocalRotation;
            
            OnPlayerInventoryChanged?.Invoke();
        }
    }

    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
            OnPlayerInventoryDisplayRequested?.Invoke(primaryInventorySystem, offset);

    }

    
    private void AutoPer10Seconds()                          // автоматического сохранение каждую минуту
    {
        //SaveGameManager.data.playerInventory = new InventorySaveData(primaryInventorySystem, transform.parent.position, transform.parent.rotation);
        SaveGameManager.data.playerInventory.InvSystem = primaryInventorySystem;
        SaveGameManager.data.playerInventory.Position = transform.parent.position;
        SaveGameManager.data.playerInventory.Rotation = transform.parent.rotation;

        //Debug.Log($"Position {SaveGameManager.data.playerInventory.Position}");
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
