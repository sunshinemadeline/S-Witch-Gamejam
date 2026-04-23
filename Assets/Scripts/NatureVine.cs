using UnityEngine;

public class NatureVine : Interactable
{
    [Header("Nature Vine")]
    public GameObject vineObject;

    private bool hasGrown = false;

    protected override void Activate()
    {
        if (hasGrown) return;

        hasGrown = true;

        if (vineObject != null)
        {
            vineObject.SetActive(true);
        }

        Debug.Log("Vine grown!");
    }
}