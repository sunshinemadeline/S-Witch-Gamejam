using UnityEngine;

public class PlayerElementSwitch : MonoBehaviour
{
    public enum Element
    {
        Water,
        Sand,
        Nature
    }

    public Element currentElement = Element.Water;

    public SpriteRenderer spriteRenderer;
    public Color waterColor = Color.cyan;
    public Color sandColor = new Color(0.9f, 0.8f, 0.5f);
    public Color natureColor = new Color(40, 96, 0);

    void Start()
    {
        UpdateVisual();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentElement = Element.Water;
            UpdateVisual();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentElement = Element.Sand;
            UpdateVisual();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentElement = Element.Nature;
            UpdateVisual();
        }
    }

    void UpdateVisual()
    {
        if (spriteRenderer == null) return;

        switch (currentElement)
        {
            case Element.Water:
                spriteRenderer.color = waterColor;
                break;

            case Element.Sand:
                spriteRenderer.color = sandColor;
                break;

            case Element.Nature:
                spriteRenderer.color = natureColor;
                break;
        }
    }

    public Element GetCurrentElement()
    {
        return currentElement;
    }
}
