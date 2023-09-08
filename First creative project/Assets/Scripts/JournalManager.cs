using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JournalManager : MonoBehaviour
{
    [SerializeField] private GameObject journal;
    [SerializeField] private GameObject manualWindow;
    [SerializeField] private GameObject CentreMarker;

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.jKey.wasPressedThisFrame && !journal.activeSelf)
            OpenJournal();
        else if (Keyboard.current.jKey.wasPressedThisFrame && journal.activeSelf) 
            CloseJournal();
    }

    public void OpenJournal()
    {
        journal.SetActive(true);

        if (!Cursor.visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            CentreMarker.SetActive(false);
        }
    }

    public void CloseJournal()
    {
        journal?.SetActive(false);

        if (Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            CentreMarker.SetActive(true);
        }
    }

    public void OpenManual()
    {
        manualWindow.SetActive(true);

        journal.SetActive(false);
    }

    public void Closemanual()
    {
        manualWindow.SetActive(false);

        journal.SetActive(true);
    }
}
