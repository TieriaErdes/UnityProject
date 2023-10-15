using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class TemperatureSystem : MonoBehaviour
{
    public int temperature;
    public GlobalTime globalTime;
    public TextMeshProUGUI text;

    public bool isFireNear;
    [SerializeField] private int temperatureFromFire = 10;
    public int temperatureRadius = 10;

    public GameObject bonfire;

    private int cheaksPerHour = 10;


    private void Start()
    {
        //InvokeRepeating("TemperatureCounter", 0, globalTime.dayCycle.DayDuration / (24 * cheaksPerHour));
    }

    private void Update()
    {
        TemperatureCounter();

        text.text = temperature + " °C";
    }

    private void TemperatureCounter()
    {
        switch (globalTime.hours)
        {
            case 1:
                temperature = 22;
                break;
            case 2:
                temperature = 21;
                break;
            case 3:
                temperature = 20;
                break;
            case 4:
                temperature = 18;
                break;          
            case 5:             
                temperature = 19;
                break;          
            case 6:             
                temperature = 19;
                break;
            case 7:
                temperature = 20;
                break;
            case 8:
                temperature = 21;
                break;
            case 9:
                temperature = 22;
                break;
            case 10:
                temperature = 23;
                break;
            case 11:
                temperature = 25;
                break;
            case 12:
                temperature = 27;
                break;
            case 13:
                temperature = 29;
                break;
            case 14:
                temperature = 31;
                break;
            case 15:
                temperature = 31;
                break;
            case 16:
                temperature = 30;
                break;
            case 17:
                temperature = 29;
                break;
            case 18:
                temperature = 28;
                break;
            case 19:
                temperature = 27;
                break;
            case 20:
                temperature = 28;
                break;
            case 21:
                temperature = 26;
                break;
            case 22:
                temperature = 24;
                break;
            case 23:
                temperature = 23;
                break;
            default:
                break;
        }

        if (isFireNear)
        {
            temperature += temperatureFromFire;
        }
        
    }
}
