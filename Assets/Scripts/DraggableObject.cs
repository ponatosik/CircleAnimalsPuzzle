using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
	Vector3 _draggPosOffset;
	float _objectZPos;


	private void OnMouseDown()
	{
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		_draggPosOffset = mouseWorldPos - (Vector2)transform.position;
		_objectZPos = transform.position.z;
	}

	private void OnMouseDrag()
	{
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPos.z = _objectZPos;
		mouseWorldPos -= _draggPosOffset;
		transform.position = mouseWorldPos;
	}
}
