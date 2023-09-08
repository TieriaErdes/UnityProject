using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private GameObject _slotHighlight;
    [SerializeField] private TextMeshProUGUI itemCout;
    [SerializeField] private InventorySlot assignedInventorySlot;

    private Button button;

    public InventorySlot AssignedInventorySlot => assignedInventorySlot;
    public InventoryDisplay ParentDisplay {get; private set;} 

    private void Awake()
    {
        ClearSlot();

        itemSprite.preserveAspect = true;

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

            if (slot.StackSize > 1) itemCout.text = slot.StackSize.ToString();
            else itemCout.text = "";
        }
        else
        {
            //Debug.Log("Slot cleared");
            //ClearSlot();
            itemSprite.color = Color.clear;
            itemSprite.sprite = null;
            itemCout.text = "";
        }
    }

    public void ToggleHighlight()
    {
        _slotHighlight.SetActive(!_slotHighlight.activeInHierarchy);

        /// TODO: —ƒ≈À¿“‹ Œ¡ÕŒ¬À≈Õ»≈ »Õ“≈–‘≈…—¿ »Õ¬≈Õ“¿–ﬂ œŒ  ƒ
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

        //button = GetComponent<Button>();
        //button?.onClick.AddListener(OnUISlotClick);
    }

    public void OnUISlotClick()
    {
        // Access display class func
        ParentDisplay?.SlotClicked(this);
    }
}
