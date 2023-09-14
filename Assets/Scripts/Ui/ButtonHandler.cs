using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void StartGame()
    {
        if (LevelManager.Instance != null)
        {
            Destroy(LevelManager.Instance.gameObject);
        }
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        if (LevelManager.Instance != null)
        {
            Destroy(LevelManager.Instance.gameObject);
        }
        SceneManager.LoadScene("MainMenu");
    }
}
