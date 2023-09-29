using System;
using UnityEngine;

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
			Debug.LogWarning($"Attempt to create second instance of {nameof(LevelManager)}");
			Destroy(this);
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
}
