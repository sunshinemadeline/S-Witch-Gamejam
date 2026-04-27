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

    [Header("Sprite Renderer")]
    public SpriteRenderer spriteRenderer;

    [Header("Element Sprites")]
    public Sprite waterSprite;
    public Sprite sandSprite;
    public Sprite natureSprite;

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
                spriteRenderer.sprite = waterSprite;
                break;

            case Element.Sand:
                spriteRenderer.sprite = sandSprite;
                break;

            case Element.Nature:
                spriteRenderer.sprite = natureSprite;
                break;
        }
    }

    public Element GetCurrentElement()
    {
        return currentElement;
    }
}
