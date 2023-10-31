using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;

	[SerializeField]
	private SpriteRenderer _sprite;

	private Vector3 _startposition;
	private float _repeatwidth;


	void Start()
    {
		_startposition = transform.position;
		_repeatwidth = _sprite.size.x * _sprite.transform.lossyScale.x;
    }
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
        if (transform.position.x < _startposition.x - _repeatwidth || transform.position.x > _startposition.x + _repeatwidth)
        {
            transform.position = _startposition;
        }
	} 
}
