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

    [SerializeField] private TextMeshProUGUI questNameShortInfo;
    [SerializeField] private TextMeshProUGUI goalTypeShortInfo;
    [SerializeField] private TextMeshProUGUI complitionShortInfo;

    private void Awake()
    {
        currentQuest.isActive = true;

        //InvokeRepeating("VisualizeQuestInfoFor10Seconds", 0, 10.0f);
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
        VisualizeQuestInfo();
    }

    public void GetNextQuest()
    {
        if (indexOfTheCurrentQuest < QuestList.Count - 1)               // -1 потому что количество != индекс
        {
            indexOfTheCurrentQuest++;
            currentQuest = QuestList[indexOfTheCurrentQuest];
            currentQuest.isActive = true;
        }
    }

    public void VisualizeQuestInfo()
    {
        questNameShortInfo.text = currentQuest.title.ToString();
        goalTypeShortInfo.text = currentQuest.goal.goalType.ToString();
        complitionShortInfo.text = currentQuest.goal.currentAmount.ToString() + " / " + currentQuest.goal.requiredAmount.ToString();
    }
}
