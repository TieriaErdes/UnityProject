using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestGiver : MonoBehaviour
{
    public QuestNormal quest;

    public player_main player;

    public GameObject CentreMarker;
    public GameObject journal;

    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI goldText;
    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();

        if (!Cursor.visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            CentreMarker.SetActive(false);
        }

        journal.SetActive(false);
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);

        journal.SetActive(true);
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;                      // Выдаём квест игроку
        player.quest = quest;

        if (Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            CentreMarker.SetActive(true);
        }
    }

    private void Update()
    {
        //if (Keyboard.current.jKey.wasPressedThisFrame)
        //    OpenQuestWindow();

        //else if (Keyboard.current.jKey.wasPressedThisFrame && questWindow.activeSelf)
        //    CloseQuestWindow();
    }
}
