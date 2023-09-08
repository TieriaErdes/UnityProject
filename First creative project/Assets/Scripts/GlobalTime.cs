using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GlobalTime : MonoBehaviour
{
    public DayCycle dayCycle;
    public int Day = 1;

    public string CurrentDayOfWeek;
    public string CurrentTime;

    private List<string> dayOfWeek = new List<string>()
        { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
    public int hours, minutes;
    private float variableHour;
    private float variableMinute;

    private void Start()
    {
        variableHour = dayCycle.DayDuration / 24;                   // 24 часа
        variableMinute = dayCycle.DayDuration / (24 * 60);          // 24 часа и 60 минут
    }

    private void TimeCounter()
    {
        if (Time.fixedTime > (dayCycle.DayDuration * Day))
        {
            Day++;
        }

        hours = (int)((dayCycle.TimeOfDay * dayCycle.DayDuration) / variableHour) + 5;              // —читаем, что день начинаетс€ с 5 утра
        minutes = (int)(((dayCycle.TimeOfDay * dayCycle.DayDuration) / variableMinute) % 60);       // умножаем на 60 потому что в часе 60 минут как не крути

        if (minutes <= 9 && hours < 24)
            CurrentTime = hours + ":0" + minutes;
        else if (minutes > 9 && hours < 24)
            CurrentTime = hours + ":" + minutes;
        else if (minutes <= 9 && hours > 24)
            CurrentTime = (hours - 24) + ":0" + minutes;
        else 
            CurrentTime = (hours - 24) + ":" + minutes;
    }


    public TextMeshProUGUI textWeek;
    public TextMeshProUGUI textDay;
    public TextMeshProUGUI textTime;

    private void Update()
    {
        TimeCounter();

        textDay.text = "Day: " + Day;
        textTime.text = CurrentTime;
        CurrentDayOfWeek = dayOfWeek[Day % 7 - 1];                     // 7 дней недели -- размер dayOfWeek;  -1 потому что отсчЄт дней ведЄм с 1
        textWeek.text = CurrentDayOfWeek;
    }
}
