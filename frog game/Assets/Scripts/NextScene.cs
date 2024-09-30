using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AdvanceScene : MonoBehaviour
{
    public GameObject exitPanel;
    public GameObject playButton;
    private static string lastSceneName;


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Frog Die" && Input.GetKeyDown(KeyCode.Space))
        {
            LoadLastScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextScene()
    {
        lastSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void openExitPanel()
    {
        if (exitPanel != null)
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
        lastSceneName = SceneManager.GetActiveScene().name; // Store the current scene before changing
        SceneManager.LoadScene(name);
    }

    public void LoadLastScene()
    {
        if (!string.IsNullOrEmpty(lastSceneName))
        {
            SceneManager.LoadScene(lastSceneName);
        }
    }

}
