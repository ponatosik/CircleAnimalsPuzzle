using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressStorage : MonoBehaviour
{
	public static LevelProgressStorage Instance { get; private set; }

	[SerializeField]
	private Dictionary<string, LevelProgressData> _cache = new Dictionary<string, LevelProgressData>();

	public LevelProgressData LoadProgressData(string fileName)
	{
		if (!FileUtils.ReadObjectFromJsonFile(fileName, out LevelProgressData result))
		{
			Debug.LogWarning($"Unable to read {nameof(LevelProgressData)} from file: {fileName}, creating new progress data file");
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
