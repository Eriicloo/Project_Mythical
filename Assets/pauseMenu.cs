using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public string key1 = "Level4";
    public string key2 = "Level2";
    public string key3 = "Level3";

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        GameIsPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt(key1, 0);
        PlayerPrefs.SetInt(key2, 0);
        PlayerPrefs.SetInt(key3, 0);
        SceneManager.LoadScene("Level1");
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
