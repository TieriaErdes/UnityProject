using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[RequireComponent(typeof(UniqueID))]
public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius = 1f;
    public Inventory_itemData ItemData;

    [SerializeField] private float _rotationSpeed = 20f;

    public PlayerInventoryHolder inventory;

    //private SphereCollider myCollider;

    private string id;

    [SerializeField] private ItemPickUpSaveData itemSaveData;
    private void Awake()
    {
        
        SaveLoad.OnLoadGame += LoadGame;
        itemSaveData = new ItemPickUpSaveData(ItemData, transform.position, transform.rotation); ;


        //myCollider = GetComponent<SphereCollider>();
        //myCollider.isTrigger = true;
        //myCollider.radius = PickUpRadius;

        inventory = FindAnyObjectByType<PlayerInventoryHolder>();
    }

    private void Start()
    {
        id = GetComponent<UniqueID>().ID;
        SaveGameManager.data.activeItems.Add(id, itemSaveData);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);


    }

    private void LoadGame(SaveData data)
    {
        if (data.collectedItems.Contains(id)) { Destroy(this.gameObject); }
    }

    private void OnDestroy()
    {
        if (SaveGameManager.data.activeItems.ContainsKey(id)) { SaveGameManager.data.activeItems.Remove(id); }
        SaveLoad.OnLoadGame -= LoadGame;
    }

    //private void OnTriggerEnter(Collider other)
    //{
        

    //    var inventory = other.transform.GetComponent<PlayerInventoryHolder>();

    //    if (!inventory) return;

    //    //Debug.Log("ItemPickUp OnTriggerEnter");

    //    if (inventory.AddToInventory(ItemData, 1))
    //    {
    //        SaveGameManager.data.collectedItems.Add(id);
    //        Destroy(this.gameObject);
    //    }
    //}

    public void PickUpItem(GameObject other)
    {
        //var inventory = other.transform.GetComponent<PlayerInventoryHolder>();

        if (!inventory) return;

        if (inventory.AddToInventory(ItemData, 1))
        {
            SaveGameManager.data.collectedItems.Add(id);
            Destroy(this.gameObject);
        }
    }

    public string SetDescription()
    {
        return ItemData.Description;
    }    
}

[System.Serializable]
public struct ItemPickUpSaveData
{
    public Inventory_itemData ItemData;
    public Vector3 Position;
    public Quaternion Rotation;

    public ItemPickUpSaveData(Inventory_itemData _data, Vector3 _position, Quaternion _rotation)
    {
        ItemData = _data;
        Position = _position;
        Rotation = _rotation;
    }
}
