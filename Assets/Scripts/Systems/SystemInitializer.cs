using System.Collections;
using System.Collections.Generic;
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
