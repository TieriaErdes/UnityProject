using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public abstract class InventoryHolder : MonoBehaviour
{
    /// <summary>
    /// ��� ����� ����� ����� ������� ���������� �������� 
    /// ������ � ������ ���������
    /// </summary>

    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem primaryInventorySystem;
    [SerializeField] protected int offset = 10;

    public int Offset => offset;

    public InventorySystem PrimaryInventorySystem => primaryInventorySystem;

    public static UnityAction<InventorySystem, int> OnDynamicInventoryDisplayRequested;   // Inv system to display ammount to offset display by
    /// </summary>

    //public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    protected virtual void Awake()
    {
        SaveLoad.OnLoadGame += LoadInventory;

        primaryInventorySystem = new InventorySystem(inventorySize);
    }

    protected abstract void LoadInventory(SaveData saveData);
}


[System.Serializable]
public struct InventorySaveData
{
    public InventorySystem InvSystem;
    public Vector3 Position;
    public Quaternion Rotation;

    public InventorySaveData(InventorySystem _invSystem, Vector3 _position, Quaternion _rotatoin)
    {
        InvSystem = _invSystem;
        Position = _position;
        Rotation = _rotatoin;
    }

    public InventorySaveData(InventorySystem _invSystem)
    {
        InvSystem = _invSystem;
        Position = Vector3.zero;
        Rotation = Quaternion.identity;
    }
}



