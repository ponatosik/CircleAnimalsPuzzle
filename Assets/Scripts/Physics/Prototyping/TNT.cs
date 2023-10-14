using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
	private bool _isActive;
	private GameObject _destroyedObject;

	void Start()
	{
		_isActive = gameObject.activeSelf;
		GameManager.OnLevelStopped += SetActive;
	}

	private void OnDestroy()
	{
		GameManager.OnLevelStopped -= SetActive;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<BlowableObject>()) 
		{
			_destroyedObject = collision.gameObject;
			_destroyedObject.SetActive(false);
			gameObject.SetActive(false);
		}
	}

	private void SetActive()
	{
		gameObject.SetActive(true);
		if (_destroyedObject) 
		{
			_destroyedObject.SetActive(true);
			_destroyedObject = null;
		}
	}
}
