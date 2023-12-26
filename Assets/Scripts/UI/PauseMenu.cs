using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    TransitionEffect _transitionEffect;

    public void Pause()
    {
        GameManager.Instance.PauseGame();
		_transitionEffect.Activate();

	}

    public void Resume()
    {
		_transitionEffect.Deactivate();
		GameManager.Instance.UnpauseGame();
    }

    public void Restart()
    {
		LevelSystem.Instance.LoadLevel(LevelSystem.Instance.LoadedLevel);
        GameManager.Instance.UnpauseGame();
    }

    public void Menu()
    {
        LevelSystem.Instance.LoadMainMenu();
    }
}
