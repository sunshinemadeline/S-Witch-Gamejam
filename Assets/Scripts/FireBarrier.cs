using UnityEngine;

public class FireBarrier : Interactable
{
    [Header("Fire Barrier")]
    public GameObject fireVisual;
    public Collider2D blockingCollider;

    private bool isExtinguished = false;

    protected override void Activate()
    {
        if (isExtinguished) return;

        isExtinguished = true;

        if (fireVisual != null)
        {
            fireVisual.SetActive(false);
        }

        if (blockingCollider != null)
        {
            blockingCollider.enabled = false;
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.fireExtinguishSFX);
        }

        Debug.Log("Fire extinguished!");
    }
}