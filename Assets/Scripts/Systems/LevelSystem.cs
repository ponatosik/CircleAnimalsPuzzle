using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
	public static LevelSystem Instance { get; private set; }

	[SerializeField]
	private Level[] _levels;

	[SerializeField]
	private Level _mainMenu;

	[SerializeField]
	private string _lastUnlcockedLevelPrefsStr = "Levels.LastUnlocked";

	public Level LoadedLevel { get; private set; } = null;
	public Level PreviousLoadedLevel { get; private set; } = null;
	public Level GetLastUnlcockedLevel()
	{
		int levelIndex = PlayerPrefs.GetInt(_lastUnlcockedLevelPrefsStr, -1);
		if (levelIndex == -1 || levelIndex >= _levels.Length) 
		{
			return null;
		}

		Level level = _levels[levelIndex];
        if (!level.Unlocked)
        {
			return null;
		}

        return level;
	}
	

	public Level[] Levels => _levels;

    public Level[] GetLevels() 
	{
		return _levels;
	}

	public void LoadLevel(Level level)
	{
		SceneManager.LoadScene(level.SceneName);
		PreviousLoadedLevel = LoadedLevel;
		LoadedLevel = level;
	}

	public void LoadMainMenu()
	{
		LoadLevel(_mainMenu);
	}

	public void LoadNextLevel() 
	{
		Level nextLevel = GetNextLevel();
		if (nextLevel == _mainMenu) 
		{
			Debug.Log("That was last level, loading main menu...");
			return;
		}
		LoadLevel(nextLevel);
	}

	public void UnlockNextLevel()
	{
		Level nextLevel = GetNextLevel();
        if (!nextLevel.Unlocked)
        {
			nextLevel.Unlock();
			int levelIndex = Array.IndexOf(_levels, nextLevel);
			PlayerPrefs.SetInt(_lastUnlcockedLevelPrefsStr, levelIndex);
		}
	}

	public void UnlockAndLoadNextLevel() 
	{
		UnlockNextLevel();
		LoadNextLevel();
	}

	public void CompleteCurrentLevel(int stars) 
	{
		if(stars > LoadedLevel.Stars) 
		{
			LoadedLevel.CompleteWithStars(stars);
		}
	}

	public Level GetNextLevel()
	{
		if (LoadedLevel == _levels[^1])
		{
			return _mainMenu;
		}

		int currentLevelIndex = Array.IndexOf(_levels, LoadedLevel);
		return _levels[currentLevelIndex + 1];
	}

	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError($"Attempt to create second instance of {nameof(GameManager)}");
			Destroy(this);
			return;
		}

		Instance = this;
	}

	void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			// If the game is run from executable (built game), then load main menu
			LoadMainMenu();
		}
		else 
		{
			// If the game is run from engine, then try to undestand which level is loaded
			LoadedLevel = TryFindLoadedLevel();
		}

		_levels[0].Unlock();
	}

	private Level TryFindLoadedLevel() 
	{
		string loadedSceneName = SceneManager.GetActiveScene().name;
		if (loadedSceneName == _mainMenu.SceneName) 
		{
			return _mainMenu;
		}
		return Array.Find(_levels, level => level.SceneName == loadedSceneName);
	}
}
