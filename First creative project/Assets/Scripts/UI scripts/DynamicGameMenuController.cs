using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class DynamicGameMenuController : MonoBehaviour
{
    [FormerlySerializedAs("chestPanel")] public DynamicInventoryDisplay inventoryPanel;
    public DynamicInventoryDisplay playerBackpackPanel;

    //[SerializeField] public DynamicGameMenuDisplay pauseMenu;

    private void Awake()
    {
        this.gameObject.SetActive(false);

        Debug.Log("Механика меню паузы запущена");
    }

    //private void OnEnable()
    //{
    //    if (Keyboard.current.escapeKey.wasPressedThisFrame && !inventoryPanel.gameObject.activeSelf
    //                                                       && !playerBackpackPanel.gameObject.activeSelf)
    //        this.gameObject.SetActive(true);
    //}

    //private void OnDisable()
    //{
    //    if (this.gameObject.activeSelf && Keyboard.current.escapeKey.wasPressedThisFrame)
    //        this.gameObject.SetActive(false);
    //}

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !inventoryPanel.gameObject.activeSelf
                                                           && !playerBackpackPanel.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
            Debug.LogWarning("Меню паузы активировано");
        }

        else if (this.gameObject.activeSelf && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            this.gameObject.SetActive(false);
            Debug.LogWarning("Меню паузы закрыто");
        }
    }
}
