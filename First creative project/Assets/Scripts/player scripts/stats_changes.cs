using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats_changes : MonoBehaviour
{
    [SerializeField] private player_main p_main;
    public Image healthBarMask, staminaBarMask, thirstBarMask, hungerBarMask;
    public Image healthBarFill, staminaBarFill, thirstBarFill, hungerBarFill;
    //public Color healthBarColor, staminaBarColor, thirstBarColor, hungerBarColor;

    public int Maximum;
    public int CurrentHealth, CurrentStamina, CurrentThirst, CurrentHunger;

    
    // Start is called before the first frame update
    void Start()
    { 
        //p_main = GameObject.Find("Player").GetComponent<player_main>();

        /*SetColor(healthBarFill, healthBarColor);
        SetColor(staminaBarFill, staminaBarColor);
        SetColor(thirstBarFill, thirstBarColor);
        SetColor(hungerBarFill, hungerBarColor);*/
    }

    // Update is called once per frame
    void Update()
    {
        //SetCurrent();
        CurrentHealth = p_main.hitPoints;
        CurrentStamina = (int)p_main.staminaPoints;
        CurrentThirst = p_main.thirstPoints;
        CurrentHunger = p_main.hungerPoints;

        GetCurrentFill(healthBarMask, CurrentHealth);
        GetCurrentFill(staminaBarMask, CurrentStamina);
        GetCurrentFill(thirstBarMask, CurrentThirst);
        GetCurrentFill(hungerBarMask, CurrentHunger);
    }

    void GetCurrentFill(Image mask, int current)
    {
        float fillAmount = (float)current / (float)Maximum;
        mask.fillAmount = fillAmount;
    }

    void SetCurrent()
    {
        CurrentHealth = (int)p_main.hitPoints;
        CurrentStamina = (int)p_main.staminaPoints;
        CurrentThirst = (int)p_main.thirstPoints;
        CurrentHunger = (int)p_main.hungerPoints;
    }

    //void SetColor(Image fill, Color color)
    //{
    //    fill.color = color;
    //}

}
