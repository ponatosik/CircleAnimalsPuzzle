using System.IO;
using UnityEditor;
using UnityEngine;

public class FileUtils
{
	public static void SaveObjectAsJson(string fileName, object obj) 
	{
		string jsonData = JsonUtility.ToJson(obj);
		string fullPath = Path.Combine(Application.persistentDataPath, fileName);
		File.WriteAllText(fullPath, jsonData);
	}

	public static bool ReadObjectFromJsonFile<T>(string fileName, out T obj)
	{
		obj = default;

		string fullPath = Path.Combine(Application.persistentDataPath, fileName);
		if (!File.Exists(fullPath))
		{
			return false;
		}

		string json = File.ReadAllText(fullPath);
		obj = JsonUtility.FromJson<T>(json);
		return true;
	}


	[MenuItem("Tools/Clear progress")]
	public static void ClearApplicationFiles() 
	{
		Debug.Log("Deleting game data...");

		string[] filePaths = Directory.GetFiles(Application.persistentDataPath);
		foreach (string path in filePaths) 
		{
			Debug.Log($"Deleting file {path}");
			File.Delete(path);
		}
	}
}

