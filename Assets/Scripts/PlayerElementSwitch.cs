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
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentElement = Element.Sand;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentElement = Element.Nature;
        }
    }

    public Element GetCurrentElement()
    {
        return currentElement;
    }
}