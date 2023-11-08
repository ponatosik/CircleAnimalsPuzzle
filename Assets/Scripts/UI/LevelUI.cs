using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public void NextLevel()
    {
        GameManager.Instance.LoadNextLevel();
    }

    public void ReturnToMenu()
    {
        LevelSystem.Instance.LoadMainMenu();
    }
}
