using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollectableObject : MonoBehaviour
{
	private bool _isActive;

	void Start()
	{
		_isActive = gameObject.activeSelf;
		GameManager.OnLevelStopped += Uncollect;
	}

	private void OnDestroy()
	{
		GameManager.OnLevelStopped -= Uncollect;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		Collect();
	}

	private void Collect()
	{
		GameManager.Instance.Collectables.AddCollectable(this);
		gameObject.SetActive(false);
	}

	private void Uncollect() 
	{
		GameManager.Instance.Collectables.RemoveCollectable(this);
		gameObject.SetActive(true);
	}
}
