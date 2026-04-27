using UnityEngine;

public class NatureVine : Interactable
{
    [Header("Nature Vine")]
    public GameObject vineObject;
    public GameObject vinesprite;
    public GameObject vinesprite_1;

    private bool hasGrown = false;

    protected override void Activate()
    {
        if (hasGrown) return;

        hasGrown = true;

        if (vineObject != null)
        {
            vineObject.SetActive(true);
            vinesprite.SetActive(true);
            vinesprite_1.SetActive(true);
        }

        Debug.Log("Vine grown!");
    }
}