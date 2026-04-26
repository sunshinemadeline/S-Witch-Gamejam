using TMPro;
using UnityEngine;

public class ElementUI : MonoBehaviour
{
    public PlayerElementSwitch playerElementSwitch;
    public TextMeshProUGUI elementText;

    void Update()
    {
        if (playerElementSwitch == null || elementText == null) return;

        elementText.text = "Current Spell " + playerElementSwitch.currentElement.ToString();
    }
}
