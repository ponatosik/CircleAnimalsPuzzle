using UnityEngine;
using UnityEngine.Serialization;

public class SystemInitializer : MonoBehaviour
{
	[SerializeField]
	private Systems _systemsPrefab;

    private void Awake()
	{
		if (LevelSystem.Instance == null)
		{
			Instantiate(_systemsPrefab);
		}
	}
}
