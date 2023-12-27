using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    [SerializeField] ObjectEffect finishMenuTransition;

    void Start()
    {
        GameManager.OnLevelComplete += (stars) => OnLevelComplete(stars);
    }

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

    private void OnLevelComplete(int completeWithStars)
    {
        finishMenuTransition.Activate();
        PlayStarsSound(completeWithStars);
	}

    private void PlayStarsSound(int stars) 
    {
        string soundName = GetStarsSound(stars);
        if (soundName != null) 
        {
            Debug.Log(soundName);
		    AudioManager.instance.PlaySound(soundName);
        }
	}

    private string? GetStarsSound(int stars) => stars switch
    {
        1 => "LevelEndStars1",
        2 => "LevelEndStars2",
        3 => "LevelEndStars3",
        _ => null
    };

}
