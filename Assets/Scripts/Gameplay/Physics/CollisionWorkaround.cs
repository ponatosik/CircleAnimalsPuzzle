using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CollisionWorkaround : MonoBehaviour
{
	private Vector2 _velocity = new Vector2();
	private Rigidbody2D _rigidbody2D;

	public Vector2 GetLastFrameVelocity() 
	{
		return _velocity;
	}

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		_velocity = _rigidbody2D.velocity;
	}
}
