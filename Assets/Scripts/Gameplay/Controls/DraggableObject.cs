using UnityEngine;

namespace CircleAnimalsPuzzle.Gameplay.Controlls
{
	public class DraggableObject : MonoBehaviour
	{
		Vector3 _draggPosOffset;
		float _objectZPos;

		void OnMouseDown()
		{
			if (GameManager.LevelStarted)
			{
				return;
			}

			Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_draggPosOffset = mouseWorldPos - (Vector2)transform.position;
			_objectZPos = transform.position.z;
		}

		void OnMouseDrag()
		{
			if (GameManager.LevelStarted)
			{
				return;
			}

			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mouseWorldPos.z = _objectZPos;
			mouseWorldPos -= _draggPosOffset;
			transform.position = mouseWorldPos;
		}
	}
}