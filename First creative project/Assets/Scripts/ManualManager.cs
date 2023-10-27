using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManualManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Content;
    [SerializeField] private TextMeshProUGUI[] manualContent;

    private void Awake()
    {
        Content.text = manualContent[0].text;
    }

    public void SetContent(GameObject title)
    {
        //int[] number = title.name.ToIntArray();
        //Debug.Log(number[0]);

        Content.text = manualContent[title.name.ToIntArray()[0] - 48].text;
        //Content.text = ( manualContent[title.name.ToIntArray()[0] - 48] );
    }
}
