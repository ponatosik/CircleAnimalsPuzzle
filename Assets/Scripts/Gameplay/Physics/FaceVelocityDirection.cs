using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Physics
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class FaceVelocityDirection : MonoBehaviour
	{
		private Rigidbody2D _rigidbody;

		void Start()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		void FixedUpdate()
		{
			float angle = Vector2.SignedAngle(_rigidbody.velocity, Vector2.right);
			transform.eulerAngles = new Vector3(0, 0, -angle);
			if (Mathf.Abs(angle) > 90)
			{
				transform.localScale = new Vector3(1, -1, 1);
			}
			else
			{
				transform.localScale = new Vector3(1, 1, 1);
			}
		}
	}
}