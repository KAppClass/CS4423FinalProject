using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    public static bool isPause = false;

    public void CheckPause()
    {
        if (isPause)
            {
                Pause();
            }
            else
            {
                Resume();
            }
    }

    void Pause()
    {
        Time.timeScale = 0;
        OpenOptions();
    }

    void Resume()
    {
        CloseOptions();
        Time.timeScale = 1;
    }

    public void OpenOptions()
    {
        canvas.enabled = true;
    }

    public void CloseOptions()
    {
        canvas.enabled = false;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
