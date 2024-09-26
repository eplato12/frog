using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceScene : MonoBehaviour
{
    public GameObject exitPanel;
    public GameObject playButton;

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void openExitPanel()
    {
        if(exitPanel != null)
        {
            exitPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void closeExitPanel()
    {
        if (exitPanel != null)
        {
            exitPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void toLevelMenu()
    {
        SceneManager.LoadScene("Level Menu");
    }

    public void pause()
    {
        if (playButton != null)
        {
            playButton.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void play()
    {
        if (playButton != null)
        {
            playButton.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void toLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
