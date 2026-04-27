using System.Collections;
using UnityEngine;

public class SandPlatform : Interactable
{
    [Header("Sand Platform")]
    public GameObject platformObject;
    public GameObject sandplatformsprite;
    public GameObject sandplatformsprite2;
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
            sandplatformsprite.SetActive(true);
            sandplatformsprite2.SetActive(true);
        }

        Debug.Log("Sand platform created!");

        yield return new WaitForSeconds(activeTime);

        if (platformObject != null)
        {
            platformObject.SetActive(false);
            sandplatformsprite.SetActive(false);
            sandplatformsprite2.SetActive(false);
        }

        isActive = false;
    }
}
