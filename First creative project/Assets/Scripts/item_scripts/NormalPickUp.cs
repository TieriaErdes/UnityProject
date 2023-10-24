using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NormalPickUp : MonoBehaviour
{
    [SerializeField] private LayerMask pickableLayerMask;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerCamera;
    [SerializeField][Min(1)] private float hitRange = 3;

    [SerializeField] private InputActionReference pickUpInput, descriptionInput;

    private RaycastHit hit;

    [SerializeField]
    private GameObject
        suggestionWindowUI, descriprionWindowUI;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] private Vector3 CameraPosition;

    private void Start()
    {
        //pickUpInput.action.performed += PickUp;
        //dropInput.action.performed += Drop;
        //useInput.action.performed += Use;
        //descriptionInput.action.performed += Description;
    }

    //private void Use(InputAction.CallbackContext obj)
    //{
    //    //if (inHandItem != null)
    //    //{
    //    //    IUsable usable = inHandItem.GetComponent<IUsable>();
    //    //    if (usable != null)
    //    //    {
    //    //        usable.Use(this.gameObject);
    //    //    }
    //    //}
    //}

    //private void Drop(InputAction.CallbackContext obj)
    //{
    //    //if (inHandItem != null)
    //    //{
    //    //    inHandItem.transform.SetParent(null);
    //    //    inHandItem = null;
    //    //    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
    //    //    if (rb != null)
    //    //    {
    //    //        rb.isKinematic = false;
    //    //    }
    //    //}
    //}

    private void PickUp()
    {
        if (suggestionWindowUI.activeSelf == true)
            hit.collider.GetComponent<ItemPickUp>().PickUpItem(player);

        suggestionWindowUI.SetActive(false);
    }

    private void Description()
    {
        if (suggestionWindowUI.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            suggestionWindowUI.SetActive(false);

            descriprionWindowUI.SetActive(true);
            descriprionWindowUI.GetComponentInChildren<TextMeshProUGUI>().text = hit.collider.GetComponent<ItemPickUp>().SetDescription();

        }
    }

    public void CloseDescriptionWindow()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        descriprionWindowUI.SetActive(false);
    }


    private void Update()
    {
        CameraPosition = playerCamera.transform.parent.parent.position;
        CameraPosition.y += 0.5f;

        Debug.DrawRay(CameraPosition, playerCamera.transform.forward * hitRange, Color.red);

        if (hit.collider != null)
        {
            //hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            suggestionWindowUI.SetActive(false);
        }
        if (Physics.Raycast(CameraPosition, playerCamera.transform.forward, out hit, hitRange, pickableLayerMask))
        {
            //hit.collider.GetComponent<Highlight>().ToggleHighlight(true);
            suggestionWindowUI.SetActive(true);

            itemName.text = hit.collider.GetComponent<ItemPickUp>().ItemData.DisplayName;

            if (Keyboard.current.fKey.wasPressedThisFrame)
                PickUp();

            if (Keyboard.current.gKey.wasPressedThisFrame)
                Description();
        }

    }


}
