using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SetQuestInfo : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private TextMeshProUGUI TitleText;
    [SerializeField] private TextMeshProUGUI DescriptionText;
    [SerializeField] private TextMeshProUGUI xpText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Image Icon;

    private void Awake()
    {
        TitleText.text = quest.Information.Name;
        DescriptionText.text = quest.Information.Description;
        xpText.text = quest.Reward.XP.ToString();
        coinsText.text = quest.Reward.Currency.ToString();
        Icon.sprite = quest.Information.Icon;
    }
}
