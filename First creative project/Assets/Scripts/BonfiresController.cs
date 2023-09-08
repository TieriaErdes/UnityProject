using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfiresController : MonoBehaviour
{
    public LayerMask playerlayer;
    public SphereCollider myCollider;
    [SerializeField] private TemperatureSystem temperature;


    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = temperature.temperatureRadius;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            temperature.isFireNear = true;
        }
        else 
            return;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            temperature.isFireNear = false;
        }
        else
            return;
    }
}
