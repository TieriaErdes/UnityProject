using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaminaCout : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI staminaCout;
    [SerializeField] private player_main pm;

    // Start is called before the first frame update
    

    // Update is called once per frame
    public void Update()
    {
        if (staminaCout != null)
        {
            staminaCout.text = pm.staminaPoints.ToString();
        }
    }
}
