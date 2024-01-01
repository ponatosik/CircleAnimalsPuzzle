using UnityEngine;

namespace CircleAnimalsPuzzle.Data
{
	[CreateAssetMenu(fileName = "Level", menuName = "Scriptable objects/Level")]
	public class Level : ScriptableObject
	{
		public string SceneName = "Level";
		public int MaxStars = 3;

		public bool Unlocked => GetProgressData().Unlocked;
		public int Stars => GetProgressData().Stars;


		public void Unlock()
		{
			LevelProgressData progressData = GetProgressData();
			progressData.Unlocked = true;
			LevelProgressStorage.Instance.SaveProgressData(progressData, SceneName);
		}

		public void CompleteWithStars(int stars)
		{
			LevelProgressData progressData = GetProgressData();
			progressData.Stars = stars;
			LevelProgressStorage.Instance.SaveProgressData(progressData, SceneName);
		}

		public LevelProgressData GetProgressData()
		{
			return LevelProgressStorage.Instance.LoadProgressData(SceneName);
		}
	}
}