using CircleAnimalsPuzzle.Gameplay.Collectables;
using System;
using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance { get; private set; }

		public static event Action OnLevelStarted;
		public static event Action OnLevelStopped;
		public static event Action<int> OnLevelComplete;

		public static bool LevelStarted { get; private set; }

		private bool _levelCompleted;

		[field: SerializeField]
		public CollectablesCollection Collectables { get; private set; } = new();
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
			OnLevelComplete = null;
		}

		public void StartLevel()
		{
			if (LevelStarted)
			{
				Debug.LogWarning($"Attempt to start level when it s already started");
				return;
			}

			if (_levelCompleted)
			{
				Debug.LogWarning($"Attempt to start level when it is already completed");
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
				Debug.LogWarning($"Attempt to stop level when it is already stopped");
				return;
			}

			if (_levelCompleted)
			{
				Debug.LogWarning($"Attempt to stop level when it is already completed");
				return;
			}

			LevelStarted = false;
			OnLevelStopped?.Invoke();
		}

		public void CompleteLevelWithDelay(float delay)
		{
			_levelCompleted = true;
			Invoke(nameof(CompleteLevel), delay);
		}

		public void CompleteLevel()
		{
			_levelCompleted = true;
			int collectedNumber = Collectables.GetCollectedNumber();
			OnLevelComplete?.Invoke(collectedNumber);
			LevelSystem.Instance.CompleteCurrentLevel(collectedNumber);
			LevelSystem.Instance.UnlockNextLevel();
		}

		public void LoadNextLevel()
		{
			LevelSystem.Instance.UnlockAndLoadNextLevel();
		}
	}
}