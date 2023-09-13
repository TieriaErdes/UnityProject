using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestGiver : MonoBehaviour
{
    public QuestNormal currentQuest;
    public int indexOfTheCurrentQuest = 0;
    [SerializeField] private List<QuestNormal> QuestList;

    public player_main player;

    public GameObject CentreMarker;
    public GameObject journal;

    public GameObject questWindow;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI goldText;

    private void Awake()
    {
        currentQuest.isActive = true;
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = currentQuest.title;
        descriptionText.text = currentQuest.description;
        experienceText.text = currentQuest.experienceReward.ToString();
        goldText.text = currentQuest.goldReward.ToString();

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
        currentQuest.isActive = true;                      // Выдаём квест игроку
        //player.quest.quest = quest;

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

    public void GetNextQuest()
    {
        if (indexOfTheCurrentQuest < QuestList.Count)
        {
            indexOfTheCurrentQuest++;
            currentQuest = QuestList[indexOfTheCurrentQuest];
            currentQuest.isActive = true;
        }
    }
}
