using UnityEngine;

public class SystemInitializer : MonoBehaviour
{
	[SerializeField]
	private Systems systemsPrefab;

    private void Awake()
	{
		if (LevelSystem.Instance == null)
		{
			Instantiate(systemsPrefab);
		}
	}
}
