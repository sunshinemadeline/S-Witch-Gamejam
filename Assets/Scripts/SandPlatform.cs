using System.Collections;
using UnityEngine;

public class SandPlatform : Interactable
{
    [Header("Sand Platform")]
    public GameObject platformObject;
    public float activeTime = 4f;

    private bool isActive = false;

    protected override void Activate()
    {
        if (!isActive)
        {
            StartCoroutine(ActivatePlatform());
        }
    }

    private IEnumerator ActivatePlatform()
    {
        isActive = true;

        if (platformObject != null)
        {
            platformObject.SetActive(true);
        }

        Debug.Log("Sand platform created!");

        yield return new WaitForSeconds(activeTime);

        if (platformObject != null)
        {
            platformObject.SetActive(false);
        }

        isActive = false;
    }
}
