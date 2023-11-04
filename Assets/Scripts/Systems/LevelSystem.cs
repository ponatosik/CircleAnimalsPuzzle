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

	public Level LoadedLevel { get; private set; } = null;

	public Level[] GetLevels() 
	{
		return _levels;
	}

	public void LoadLevel(Level level)
	{
		SceneManager.LoadScene(level.SceneName);
		LoadedLevel = level;
	}

	public void LoadMainMenu()
	{
		LoadLevel(_mainMenu);
	}

	public void LoadNextLevel() 
	{
		if (LoadedLevel == _levels[^1]) 
		{
			Debug.Log("That was last level, loading main menu...");
			LoadMainMenu();
			return;
		}

		int currentIndex = Array.IndexOf(_levels, LoadedLevel);
		Level nextLevel = _levels[currentIndex + 1];
		LoadLevel(nextLevel);
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
			// If run game from executable (built game), then load main menu
			LoadMainMenu();
		}
		else 
		{
			// If run game from engine, then try to undestand which level is loaded
			LoadedLevel = TryFindLoadedLevel();
		}
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
