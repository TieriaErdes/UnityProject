using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject DynamicInventory;
    public GameObject PlayerInventoryPanel;
    public GameObject PlayerHotbar;
    public GameObject HotbarBackground;
    public GameObject pauseMenuPref;
    public GameObject saveButton;
    public GameObject loadBotton;
    public GameObject deleteBotton;
    public GameObject Question;
    public GameObject CentreMarker;
    public GameObject StatusBar;
    public GameObject Timer;
    public GameObject Temperature;
    //public GameObject QuestShortInfo;

    private bool isExitToMainMenu;
    
    private void Start()
    {
        pauseMenuPref.SetActive(false);
        saveButton.SetActive(false);
        loadBotton.SetActive(false);
        deleteBotton.SetActive(false);
        Question.SetActive(false);

        Time.timeScale = 1.0f;

        MusicManager.instance.PlayMusic("Ночная тема");
        Debug.Log("Первичный вызов темы");
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
            HotbarBackground.SetActive(false);
            StatusBar.SetActive(false);
            Timer.SetActive(false);
            Temperature.SetActive(false);
            //QuestShortInfo.SetActive(false);
            Time.timeScale = 0f;

            MusicManager.instance.PlayMusic("Тема меню паузы");
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
            HotbarBackground.SetActive(true);
            StatusBar.SetActive(true);
            Timer.SetActive(true);
            Temperature.SetActive(true);
            //QuestShortInfo.SetActive(true);
            Time.timeScale = 1.0f;

            MusicManager.instance.PlayMusic("Ночная тема");
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
        HotbarBackground.SetActive(true);
        StatusBar.SetActive(true);
        Timer.SetActive(true);
        Temperature.SetActive(true);
        //QuestShortInfo.SetActive(true);
        Time.timeScale = 1.0f;

        MusicManager.instance.PlayMusic("Ночная тема");
    }

    public void ExitGame()
    {
        if (isExitToMainMenu) { }
        Question.SetActive(true);
    }

    public void YesAnswer()
    {
        if (isExitToMainMenu)
            SceneManager.LoadScene(0);
        else
            Application.Quit();
    }

    public void NoAnswer()
    {
        Question.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        isExitToMainMenu = true;

        Question.SetActive(true);
    }
}
