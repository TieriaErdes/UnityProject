using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_main : MonoBehaviour
{
    Rigidbody rb;

    public int hitPoints = 100;
    public int hungerPoints = 100;
    public int thirstPoints = 100;
    public int staminaPoints = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //hitPoints = 100;
        //hungerPoints = 100;
        //thirstPoints = 100;
        //staminaPoints = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
