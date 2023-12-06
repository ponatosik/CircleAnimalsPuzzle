using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]

public class ShakeOnCollision : MonoBehaviour
{
	Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		_animator.SetTrigger("Shake");
        AudioManager.instance.PlaySound("ThreeSound");
    }
}
