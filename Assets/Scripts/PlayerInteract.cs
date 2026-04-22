using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Interactable currentInteractable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    public void SetCurrentInteractable(Interactable interactable)
    {
        currentInteractable = interactable;
    }

    public void ClearCurrentInteractable(Interactable interactable)
    {
        if (currentInteractable == interactable)
        {
            currentInteractable = null;
        }
    }
}
