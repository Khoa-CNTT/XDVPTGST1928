using UnityEngine;
using UnityEngine.UI;

public class MainGUI : MonoBehaviour
{

    public Text staminaAmt;
    public Text healthAmt;
    public Text infectionAmt;
    

    // Update is called once per frame
    void Update()
    {
        healthAmt.text = SaveScript.health + "%";
        staminaAmt.text = SaveScript.stamina.ToString("F0") + "%";
        infectionAmt.text = SaveScript.infection.ToString("F0") + "%";
    }
}
