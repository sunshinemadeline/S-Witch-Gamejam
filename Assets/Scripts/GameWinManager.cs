using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinManager : MonoBehaviour
{
    public GameObject winScreen;

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.winSFX);
        }
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainLevel");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
}