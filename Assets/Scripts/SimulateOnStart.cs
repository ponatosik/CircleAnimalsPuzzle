using UnityEngine;

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

	void Start()
    {
        _rigidbody.simulated = LevelManager.LevelStarted;

        LevelManager.OnLevelStarted += () => _rigidbody.simulated = true;
		LevelManager.OnLevelStopped += () =>
		{
			transform.position = _position;
			_rigidbody.velocity = _velocity;
			_rigidbody.angularVelocity = _angularVelocity;
			_rigidbody.simulated = false;
		};
	}
}
