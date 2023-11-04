using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systems : MonoBehaviour
{
	public static Systems Instance { get; private set; }

	void Awake()
	{
		DontDestroyOnLoad(this);
		if (Instance != null)
		{
			Debug.LogError($"Attempt to create second instance of {nameof(Systems)}");
			Destroy(this);
			return;
		}

		Instance = this;
	}
}
