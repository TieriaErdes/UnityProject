using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UniqueID))]

public class ChestInventory : InventoryHolder, IInteractable
{
    public UnityAction<IInteractable> OnInterationComplete { get; set; }

    protected override void Awake()
    {
        base.Awake();
        SaveLoad.OnLoadGame += LoadInventory;
    }

    private void Start()
    {
        var chestSaveData = new ChestSaveData(PrimaryInventorySystem, transform.position, transform.rotation);

        SaveGameManager.data.chestDictionary.Add(GetComponent<UniqueID>().ID, chestSaveData);
    }

    private void LoadInventory(SaveData data)
    {
        // Проверяем data для конкретно этого сундука и если он существует, то загружаем его
        if (data.chestDictionary.TryGetValue(GetComponent<UniqueID>().ID, out ChestSaveData chestData))
        {
            this.primaryInventorySystem = chestData.invSystem;
            this.transform.position = chestData.position;
            this.transform.rotation = chestData.rotation;
        }
    }

    public void Interact(Interactor interactor, out bool interactSuccessful)
    {
        OnDynamicInventoryDisplayRequested?.Invoke(PrimaryInventorySystem);
        interactSuccessful = true;
    }
    public void EndIntetaction()
    {

    }

}

[System.Serializable]
public struct ChestSaveData
{
    public InventorySystem invSystem;
    public Vector3 position;
    public Quaternion rotation;

    public ChestSaveData(InventorySystem _invSystem, Vector3 _position, Quaternion _rotatoin)
    {
        invSystem = _invSystem;
        position = _position;
        rotation = _rotatoin;
    }
}
