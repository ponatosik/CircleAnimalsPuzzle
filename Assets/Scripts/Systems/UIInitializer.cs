using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInitializer : MonoBehaviour
{
	[SerializeField]
	private GameObject UIPrefab;

	private void Awake()
	{
		if (!GameObject.FindGameObjectWithTag(UIPrefab.tag)) 
		{
			Instantiate(UIPrefab);
		}
	}
}
