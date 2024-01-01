using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintObject : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _renderer;

	public void Display()
	{
		_renderer.enabled = true;
	}

	private void Awake()
	{
		_renderer.enabled = false;
	}
}
