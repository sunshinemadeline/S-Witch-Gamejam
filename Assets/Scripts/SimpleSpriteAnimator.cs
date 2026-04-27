using UnityEngine;

public class SimpleSpriteAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] animationFrames;
    public float frameRate = 8f;

    private int currentFrame;
    private float timer;

    void Update()
    {
        if (spriteRenderer == null || animationFrames == null || animationFrames.Length == 0)
            return;

        timer += Time.deltaTime;

        if (timer >= 1f / frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % animationFrames.Length;
            spriteRenderer.sprite = animationFrames[currentFrame];
        }
    }
}
