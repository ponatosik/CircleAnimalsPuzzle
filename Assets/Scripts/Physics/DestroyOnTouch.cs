using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DestroyOnTouch : MonoBehaviour
{
	private bool _isActive;

	void Start()
	{
		_isActive = gameObject.activeSelf;
		GameManager.OnLevelStopped += SetActive;
	}

	private void OnDestroy()
	{
		GameManager.OnLevelStopped -= SetActive;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		gameObject.SetActive(false);
	}

	private void SetActive() 
	{
		gameObject.SetActive(true);
	}
}
