using UnityEngine;

public class PlayerElementSwitch : MonoBehaviour
{
    public enum Element
    {
        Water,
        Sand,
        Nature
    }

    [Header("Current Element")]
    public Element currentElement = Element.Water;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentElement = Element.Water;
            PlaySwitchSound();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentElement = Element.Sand;
            PlaySwitchSound();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentElement = Element.Nature;
            PlaySwitchSound();
        }
    }

    void PlaySwitchSound()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.switchSFX);
        }
    }

    public Element GetCurrentElement()
    {
        return currentElement;
    }
}