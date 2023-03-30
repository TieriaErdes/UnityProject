using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInventory : InventoryHolder, IInteractable
{
    
    public UnityAction<IInteractable> OnInterationComplete { get; set; }

    public void Interact(Interactor interactor, out bool interactSuccessful)
    {
        OnDynamicInventoryDisplayRequested?.Invoke(InventorySystem);
        interactSuccessful = true;
    }
    public void EndIntetaction()
    {

    }

    
}
