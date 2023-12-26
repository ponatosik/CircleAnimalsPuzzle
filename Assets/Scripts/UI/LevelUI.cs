using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    [SerializeField] GameObject finishMenu;

    public void NextLevel()
    {
        GameManager.Instance.LoadNextLevel();
    }

    public void ReturnToMenu()
    {
        LevelSystem.Instance.LoadMainMenu();
    }

    public void RestartLevel()
    {
        LevelSystem.Instance.LoadLevel(LevelSystem.Instance.LoadedLevel);
        GameManager.Instance.UnpauseGame();
    }
}
