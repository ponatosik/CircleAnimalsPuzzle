using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
	public static LevelSystem Instance { get; private set; }

	[SerializeField]
	private Level[] _levels;

	[SerializeField]
	private Level _mainLevel;

	private Level _levelLoaded = null;

	public Level[] GetLevels() 
	{
		return _levels;
	}

	public void LoadLevel(Level level)
	{
		SceneManager.LoadScene(level.SceneName);
		_levelLoaded = level;
	}

	public void LoadNextLevel() 
	{
		int currentIndex = Array.IndexOf(_levels, _levelLoaded);
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
		DontDestroyOnLoad(this);
		LoadLevel(_mainLevel);
	}

	//private void ValidateLevels() 
	//{
	//	foreach (Level level in _levels) 
	//	{
	//		if (!SceneManager.GetSceneByName(level.SceneName).IsValid()) 
	//		{
	//			Debug.LogWarning($"Invalid level {level.name}, scene with name \"{level.SceneName}\" does not exist");
	//		}
	//	}
	//}
}
