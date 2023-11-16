using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public static event Action OnLevelStarted;
	public static event Action OnLevelStopped;
	public static bool LevelStarted { get; private set; }

	[field: SerializeField]
	public CollectablesCollection Collectables { get; private set; } = new ();
	public bool GamePaused { get; private set; } = false;

	void Awake()
	{
		if (Instance != null)
		{
			Debug.Log($"Attempt to create second instance of {nameof(GameManager)}");
			Destroy(gameObject);
			return;
		}

		Instance = this;
	}

	private void OnDestroy()
	{
		if (GamePaused) 
		{
			Time.timeScale = 1;
		}

		OnLevelStarted = null;
		OnLevelStopped = null;
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

	public void PauseGame() 
	{
		GamePaused = true;
		Time.timeScale = 0;
	}
	public void UnpauseGame() 
	{
		GamePaused = false;
		Time.timeScale = 1;
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
		LevelSystem.Instance.UnlockAndLoadNextLevel();
	}
}
