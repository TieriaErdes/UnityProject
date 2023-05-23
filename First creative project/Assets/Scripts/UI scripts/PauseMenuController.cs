using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject DynamicInventory;
    public GameObject PlayerInventoryPanel;
    public GameObject PlayerHotbar;
    public GameObject pauseMenuPref;
    public GameObject saveButton;
    public GameObject loadBotton;
    public GameObject deleteBotton;
    public GameObject Question;
    public GameObject CentreMarker;
    
    private void Start()
    {
        pauseMenuPref.SetActive(false);
        saveButton.SetActive(false);
        loadBotton.SetActive(false);
        deleteBotton.SetActive(false);
        Question.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !pauseMenuPref.activeSelf
                                                           && !DynamicInventory.activeSelf && !PlayerInventoryPanel.activeSelf)
        {
            Debug.Log("Pause menu acive");
            saveButton.SetActive(true);
            loadBotton.SetActive(true);
            deleteBotton.SetActive(true);
            pauseMenuPref.SetActive(true);

            if (!Cursor.visible)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                CentreMarker.SetActive(false);
            }

            PlayerHotbar.SetActive(false);
            Time.timeScale = 0f;
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            saveButton.SetActive(false);
            loadBotton.SetActive(false);
            deleteBotton.SetActive(false);
            pauseMenuPref.SetActive(false);

            if (Cursor.visible)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                CentreMarker.SetActive(true);
            }

            PlayerHotbar.SetActive(true);
            Time.timeScale = 1.0f;
        }
    }

    public void ContinueGame()
    {
        saveButton.SetActive(false);
        loadBotton.SetActive(false);
        deleteBotton.SetActive(false);
        pauseMenuPref.SetActive(false);

        if (Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            CentreMarker.SetActive(true);
        }

        PlayerHotbar.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        Question.SetActive(true);
    }

    public void YesAnswer()
    {
        Application.Quit();
    }

    public void NoAnswer()
    {
        Question.SetActive(false);
    }
}