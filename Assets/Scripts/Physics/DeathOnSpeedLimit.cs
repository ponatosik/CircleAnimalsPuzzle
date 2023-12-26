using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DeathOnSpeedLimit : MonoBehaviour
{
    [SerializeField]
    private float _speedLimit = float.PositiveInfinity;

	private Rigidbody2D _rigidbody;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
    {
        if(_rigidbody.velocity.magnitude > _speedLimit) 
		{
			GameManager.Instance.StopLevel();
		}        
    }
}
