using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [SerializeField]
    private float _requiredSpeed = 10f;

	//[SerializeField]
	//public float _bounciness = 1f;

	private bool _isActive;

	void Start()
	{
		_isActive = gameObject.activeSelf;
		GameManager.OnLevelStarted += SetActive;
	}

	private void OnDestroy()
	{
		GameManager.OnLevelStarted -= SetActive;
	}

	private void SetActive()
	{
		gameObject.SetActive(true);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.magnitude >= _requiredSpeed)
		{
			gameObject.SetActive(false);
			collision.rigidbody.velocity = collision.relativeVelocity;
		}
		else 
		{
			//Vector2 facingVector = transform.up.normalized;
			//Rigidbody2D rigidbody = collision.rigidbody;
			//float speed = collision.relativeVelocity.magnitude;

			//rigidbody.AddForce(facingVector * speed * _bounciness, ForceMode2D.Impulse);
		}
	}
}
