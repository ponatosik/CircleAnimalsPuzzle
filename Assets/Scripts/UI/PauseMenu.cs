using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void Hint()
    {
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        GameManager.Instance.UnpauseGame();
    }

    public void Restart()
    {
        pauseMenu.SetActive(false);
        GameManager.Instance.StopLevel();
        GameManager.Instance.UnpauseGame();
    }

    public void Menu()
    {
        LevelSystem.Instance.LoadMainMenu();
    }

    public void Music()
    {

    }

    public void Sound()
    {
        
    }
}
