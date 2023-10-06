using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BouncyObject : MonoBehaviour
{
    public float Bounciness = 1f;

    [SerializeField]
    private Collider2D BouncyCollider;

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.otherCollider != BouncyCollider) 
        {
            return;
        }

        Vector2 facingVector = transform.up.normalized;
		Rigidbody2D rigidbody = collision.rigidbody;
        float speed = collision.relativeVelocity.magnitude;

		rigidbody.AddForce(facingVector * speed * Bounciness, ForceMode2D.Impulse);
	}
}
