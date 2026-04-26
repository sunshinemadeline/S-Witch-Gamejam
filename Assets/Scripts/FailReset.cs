using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallReset : MonoBehaviour
{
    public float fallThreshold = -10f;
    public float resetDelay = 0.5f;

    private bool resetting = false;

    void Update()
    {
        if (!resetting && transform.position.y < fallThreshold)
        {
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        resetting = true;
        yield return new WaitForSeconds(resetDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
