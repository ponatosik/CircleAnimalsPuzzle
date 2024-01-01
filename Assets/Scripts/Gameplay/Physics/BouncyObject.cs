using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Physics
{

	[RequireComponent(typeof(Collider2D))]
	public class BouncyObject : MonoBehaviour
	{
		public float Bounciness = 1f;

		[SerializeField]
		private Collider2D _bouncyCollider;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.otherCollider != _bouncyCollider)
			{
				return;
			}

			Vector2 facingVector = transform.up.normalized;
			Rigidbody2D rigidbody = collision.rigidbody;
			float speed = GetCollisionSpeed(collision);

			rigidbody.AddForce(facingVector * speed * Bounciness, ForceMode2D.Impulse);
		}

		public float GetCollisionSpeed(Collision2D collision)
		{
			if (collision.gameObject.TryGetComponent<CollisionWorkaround>(out CollisionWorkaround workaround))
			{
				return workaround.GetLastFrameVelocity().magnitude;
			}
			return collision.relativeVelocity.magnitude;
		}

	}
}