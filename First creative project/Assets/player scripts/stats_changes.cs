using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats_changes : MonoBehaviour
{
    public player_main p;
    public Image healthBar, staminaBar, thirstBar, hungerBar;

    // Start is called before the first frame update
    void Start()
    {
        p = gameObject.GetComponent<player_main>();
        healthBar.fillAmount = p.hitPoints / 100;
        hungerBar.fillAmount = p.hungerPoints / 100;
        thirstBar.fillAmount = p.thirstPoints / 100;
        staminaBar.fillAmount = p.staminaPoints / 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
