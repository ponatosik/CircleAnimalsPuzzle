using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance { get; private set; }

	public static event Action OnLevelStarted;
	public static event Action OnLevelStopped;
	public static bool LevelStarted { get; private set; }

	void Awake()
	{
		if (Instance != null)
		{
			Debug.Log($"Attempt to create second instance of {nameof(LevelManager)}");
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		Instance = this;
	}

	public void StartLevel() 
	{
		if (LevelStarted)
		{
			Debug.LogWarning($"Attempt to start level when it already started");
			return;
		}

		LevelStarted = true;
		OnLevelStarted?.Invoke();
	}

	public void StopLevel()
	{
		if (!LevelStarted)
		{
			Debug.LogWarning($"Attempt to stop level when it already stopped");
			return;
		}

		LevelStarted = false;
		OnLevelStopped?.Invoke();
	}

	public void LoadNextLevel()
	{
		LevelStarted = false;

		// This is prototype implementation, please do not load scenes like this in the future
		// TODO: Add place to store scenes order and metadata
		// TODO: Add loading screen

		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
		if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) 
		{
			Debug.LogError("Cannot load next level becouse it's last level");
			return;
		}

		SceneManager.LoadScene(nextSceneIndex);
	}
}
