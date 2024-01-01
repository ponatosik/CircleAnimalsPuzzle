using CircleAnimalsPuzzle.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace CircleAnimalsPuzzle.Data
{
	public class LevelProgressStorage : MonoBehaviour
	{
		public static LevelProgressStorage Instance { get; private set; }

		[SerializeField]
		private Dictionary<string, LevelProgressData> _cache = new Dictionary<string, LevelProgressData>();

		public LevelProgressData LoadProgressData(string fileName)
		{
			if (!FileUtils.ReadObjectFromJsonFile(fileName, out LevelProgressData result))
			{
				result = new LevelProgressData();
			}
			_cache[fileName] = result;
			return result;
		}

		public void SaveProgressData(LevelProgressData data, string fileName)
		{
			FileUtils.SaveObjectAsJson(fileName, data);
			_cache[fileName] = data;
		}

		void Awake()
		{
			if (Instance != null)
			{
				Debug.LogError($"Attempt to create second instance of {nameof(LevelProgressStorage)}");
				Destroy(this);
				return;
			}

			Instance = this;
		}
	}
}