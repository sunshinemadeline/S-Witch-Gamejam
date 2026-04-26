using UnityEngine;

public class HideTutorialText : MonoBehaviour
{
    public GameObject textToHide;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textToHide.SetActive(false);
        }
    }
}