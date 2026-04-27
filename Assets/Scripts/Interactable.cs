using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Interaction Settings")]
    public PlayerElementSwitch.Element requiredElement;

    protected bool playerInRange = false;
    protected PlayerElementSwitch playerElementSwitch;

    protected virtual void Update()
    {
        if (playerInRange && playerElementSwitch != null)
        {
            // Debug.Log("Player in range of " + gameObject.name);
        }
    }

    public virtual void Interact()
    {
        if (!playerInRange || playerElementSwitch == null)
            return;

        if (playerElementSwitch.currentElement == requiredElement)
        {
            Activate();
        }
        else
        {
            Debug.Log("Wrong element! Need: " + requiredElement);
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(AudioManager.Instance.wrongElementSFX);
            }
        }
    }

    protected virtual void Activate()
    {
        Debug.Log(gameObject.name + " activated!");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerElementSwitch = other.GetComponent<PlayerElementSwitch>();

            PlayerInteract playerInteract = other.GetComponent<PlayerInteract>();
            if (playerInteract != null)
            {
                playerInteract.SetCurrentInteractable(this);
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            PlayerInteract playerInteract = other.GetComponent<PlayerInteract>();
            if (playerInteract != null)
            {
                playerInteract.ClearCurrentInteractable(this);
            }
        }
    }
}
