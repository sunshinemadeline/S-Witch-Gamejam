using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameWinManager winManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winManager.ShowWinScreen();
        }
    }
}
