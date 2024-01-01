using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Physics
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class SimulateOnStart : MonoBehaviour
	{
		private Rigidbody2D _rigidbody;
		private Vector3 _position;
		private Vector3 _velocity;
		private float _angularVelocity;

		void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_position = transform.position;
			_velocity = _rigidbody.velocity;
			_angularVelocity = _rigidbody.angularVelocity;
		}

		private void OnDestroy()
		{
			GameManager.OnLevelStarted -= StartSimulating;
			GameManager.OnLevelStopped -= StopSimulating;
		}

		void Start()
		{
			_rigidbody.simulated = GameManager.LevelStarted;

			GameManager.OnLevelStarted += StartSimulating;
			GameManager.OnLevelStopped += StopSimulating;
		}

		private void StartSimulating()
		{
			_rigidbody.isKinematic = false;
			_rigidbody.simulated = true;
		}

		private void StopSimulating()
		{
			transform.position = _position;
			_rigidbody.velocity = _velocity;
			_rigidbody.angularVelocity = _angularVelocity;
			_rigidbody.isKinematic = true;
			_rigidbody.useFullKinematicContacts = true;
		}
	}
}