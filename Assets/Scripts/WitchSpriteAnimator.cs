using UnityEngine;

public class WitchSpriteAnimator : MonoBehaviour
{
    [Header("References")]
    public SpriteRenderer spriteRenderer;
    public PlayerMovement playerMovement;
    public PlayerElementSwitch elementSwitch;

    [Header("Water / Blue Sprites")]
    public Sprite[] waterIdleSprites;
    public Sprite[] waterRunSprites;
    public Sprite waterJumpSprite;
    public Sprite waterFallSprite;

    [Header("Sand / Beige Sprites")]
    public Sprite[] sandIdleSprites;
    public Sprite[] sandRunSprites;
    public Sprite sandJumpSprite;
    public Sprite sandFallSprite;

    [Header("Nature / Green Sprites")]
    public Sprite[] natureIdleSprites;
    public Sprite[] natureRunSprites;
    public Sprite natureJumpSprite;
    public Sprite natureFallSprite;

    [Header("Animation Settings")]
    public float idleFrameRate = 3f;
    public float runFrameRate = 8f;

    private float timer;
    private int frameIndex;

    void Update()
    {
        if (spriteRenderer == null || playerMovement == null || elementSwitch == null)
            return;

        float moveInput = playerMovement.GetMoveInput();
        bool isGrounded = playerMovement.IsGrounded();
        float verticalVelocity = playerMovement.GetVerticalVelocity();

        // Flip sprite when moving left/right
        if (moveInput > 0.1f)
            spriteRenderer.flipX = false;
        else if (moveInput < -0.1f)
            spriteRenderer.flipX = true;

        // Jump / fall sprites
        if (!isGrounded)
        {
            if (verticalVelocity > 0)
                spriteRenderer.sprite = GetJumpSprite();
            else
                spriteRenderer.sprite = GetFallSprite();

            return;
        }

        // Run animation
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            AnimateSprites(GetRunSprites(), runFrameRate);
        }
        // Idle animation
        else
        {
            AnimateSprites(GetIdleSprites(), idleFrameRate);
        }
    }

    void AnimateSprites(Sprite[] sprites, float frameRate)
    {
        if (sprites == null || sprites.Length == 0)
            return;

        timer += Time.deltaTime;

        if (timer >= 1f / frameRate)
        {
            timer = 0f;
            frameIndex = (frameIndex + 1) % sprites.Length;
        }

        spriteRenderer.sprite = sprites[frameIndex];
    }

    Sprite[] GetIdleSprites()
    {
        switch (elementSwitch.currentElement)
        {
            case PlayerElementSwitch.Element.Water:
                return waterIdleSprites;
            case PlayerElementSwitch.Element.Sand:
                return sandIdleSprites;
            case PlayerElementSwitch.Element.Nature:
                return natureIdleSprites;
            default:
                return waterIdleSprites;
        }
    }

    Sprite[] GetRunSprites()
    {
        switch (elementSwitch.currentElement)
        {
            case PlayerElementSwitch.Element.Water:
                return waterRunSprites;
            case PlayerElementSwitch.Element.Sand:
                return sandRunSprites;
            case PlayerElementSwitch.Element.Nature:
                return natureRunSprites;
            default:
                return waterRunSprites;
        }
    }

    Sprite GetJumpSprite()
    {
        switch (elementSwitch.currentElement)
        {
            case PlayerElementSwitch.Element.Water:
                return waterJumpSprite;
            case PlayerElementSwitch.Element.Sand:
                return sandJumpSprite;
            case PlayerElementSwitch.Element.Nature:
                return natureJumpSprite;
            default:
                return waterJumpSprite;
        }
    }

    Sprite GetFallSprite()
    {
        switch (elementSwitch.currentElement)
        {
            case PlayerElementSwitch.Element.Water:
                return waterFallSprite;
            case PlayerElementSwitch.Element.Sand:
                return sandFallSprite;
            case PlayerElementSwitch.Element.Nature:
                return natureFallSprite;
            default:
                return waterFallSprite;
        }
    }
}
