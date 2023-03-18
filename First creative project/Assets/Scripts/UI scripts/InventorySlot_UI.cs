using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCout;
    [SerializeField] private InventorySlot assignedInventorySlot;

    private Button button;

    public InventorySlot AssignedInventorySlot => assignedInventorySlot;
    public InventoryDisplay ParentDisplay {get; private set;} 

    private void Awake()
    {
        ClearSlot();

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        ParentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    public void Init(InventorySlot slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot)
    {
        if(slot.ItemData != null)
        {
            itemSprite.sprite = slot.ItemData.Icon;
            itemSprite.color = Color.white;
        }
        else
        {
            //Debug.Log("Slot cleared");
            ClearSlot();
        }

        if (slot.StackSize > 1)
            itemCout.text = slot.StackSize.ToString();
        else
            itemCout.text = "";
    }

    public void UpdateUISlot()
    {
        if (assignedInventorySlot != null)
            UpdateUISlot(assignedInventorySlot);
    }

    public void ClearSlot()
    {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCout.text = "";

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);
    }

    public void OnUISlotClick()
    {
        // Access display class func
        ParentDisplay?.SlotClicked(this);
    }
}
